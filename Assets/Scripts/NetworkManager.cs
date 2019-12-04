using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    //Singletone
    public static NetworkManager instance;

    private void Awake()
    {
        //if an instance already exists and it's not this one - destroy us
        if (instance != null && instance != this)
        {
            gameObject.SetActive(false);
        }
        else
        {
            //set instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }




    //Functions
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server.");
        CreateRoom("Test Room");
    }

    //attempts to CREATE a room
    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room: " + PhotonNetwork.CurrentRoom.Name);
    }

    //attempts to JOIN a room
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }
}
