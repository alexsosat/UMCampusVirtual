using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using WebSocketSharp;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public SelectCharacter playerOptions;
    public TextMeshProUGUI joinMessage;
    
    public void JoinGame()
    {
        if (!playerOptions.GetUserName().IsNullOrEmpty())
        {
            joinMessage.text = "Entrando al juego";
            PhotonNetwork.JoinRoom("UM");
        }
        else
        {
            joinMessage.text = "Favor de ingresar un nombre";
        }
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
        //PhotonNetwork.LoadLevel("Playground 1");
        PhotonNetwork.LoadLevel("Prototype");
    }

}
