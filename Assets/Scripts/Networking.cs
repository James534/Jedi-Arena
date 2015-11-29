using UnityEngine;
using System.Collections;

public class Networking : Photon.MonoBehaviour
{

    int counter = 0;
    Vector3[] pos = { new Vector3(7.5f, 1, 7.5f), new Vector3(7.5f, 1, -7.5f), new Vector3(-7.5f, 1, 7.5f), new Vector3(-7.5f, 1, -7.5f)};
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
        GameObject player = PhotonNetwork.Instantiate("HitBox", pos[Random.Range(0,4)], Quaternion.identity, 0);

        counter++;
        Debug.Log("Joined Room and Created Object");
    }
}