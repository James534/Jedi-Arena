using UnityEngine;
using System.Collections;

public class Networking : Photon.MonoBehaviour
{

    int counter = 0;
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
        Vector3 pos;
        if (counter == 0)
        {
             pos = new Vector3(5, 0, 5);
        }
        else
        {
            pos = new Vector3(-5, 0, -5);
        }

        GameObject player = PhotonNetwork.Instantiate("HitBox", pos, Quaternion.identity, 0);

        counter++;
        Debug.Log("Joined Room and Created Object");
    }
}