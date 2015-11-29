using UnityEngine;
using System.Collections;

public class Networking : Photon.MonoBehaviour
{

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("jedi");
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }


    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        GameObject player = PhotonNetwork.Instantiate("HitBox", new Vector3(1, 2, 1), Quaternion.identity, 0);

        Debug.Log("Joined Room and Created Object");
    }
}