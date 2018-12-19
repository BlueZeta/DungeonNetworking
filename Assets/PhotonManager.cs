using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonManager : Photon.MonoBehaviour
{
    [SerializeField] private Text connectText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject lobbyCamera;
    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("1.0");
    }

    void OnJoinedLobby()
    {
        Debug.Log("We are connected to the lobby");
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", player.transform.position, Quaternion.identity, 0);
        lobbyCamera.SetActive(false);
    }
    void Update()
    {
        connectText.text = PhotonNetwork.connectionStateDetailed.ToString();
    }

}
