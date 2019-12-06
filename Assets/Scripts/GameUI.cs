using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    public PlayerUIContainer[] playerContainers;
    public TextMeshProUGUI winText;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        InitializePlayerUI();
    }
    private void Update()
    {
        UpdatePlayerUI();
    }


    void InitializePlayerUI()
    {
        //loop thorugh all containers
        for (int x = 0; x < playerContainers.Length; ++x)
        {
            PlayerUIContainer container = playerContainers[x];

            //only enable and modify the UI containers we need
            if( x < PhotonNetwork.PlayerList.Length)
            {
                container.obj.SetActive(true);
                container.nameText.text = PhotonNetwork.PlayerList[x].NickName;
                container.hatTimeSlider.maxValue = GameManager.instance.timeToWin;
            }
            else
            {
                container.obj.SetActive(false);
            }

        }
    }

    void UpdatePlayerUI()
    {
        //loop through all players
        for (int i = 0; i < GameManager.instance.players.Length; ++i)
        {
            if(GameManager.instance.players[i] != null)
            {
                playerContainers[i].hatTimeSlider.value = GameManager.instance.players[i].curHatTime;
            }
        }
    }

    public void SetWinText(string winnerName)
    {
        winText.gameObject.SetActive(true);
        winText.text = winnerName + " wins";

    }
}

[System.Serializable]
public class PlayerUIContainer
{
    public GameObject obj;
    public TextMeshProUGUI nameText;
    public Slider hatTimeSlider;
}