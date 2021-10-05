using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    public void JoinGame()
    {
        PhotonNetwork.JoinRoom("UM");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        if (returnCode == 32758)
        {
            PhotonNetwork.CreateRoom("UM");
        }
    }


    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Playground 1");
    }

}
