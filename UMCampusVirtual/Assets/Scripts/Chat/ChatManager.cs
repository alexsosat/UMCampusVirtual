using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour, IChatClientListener
{
    private ChatClient _chatClient;
    private string _roomName = "Chat_World";

    private string _receiver = "";

    public SelectCharacter playerSettings;
    public GameObject loginForm;
    public GameObject chatForm;
    public TextMeshProUGUI chatMessages;
    

    // Start is called before the first frame update
    void Start()
    {
        _chatClient = new ChatClient(this);
        string username = playerSettings.GetUserName();
        
        print("Connecting...");
        _chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion,
            new AuthenticationValues(username));
        
    }

    public void ConnectPlayer(TMP_InputField userNameField)
    { 
        print("Connecting...");
        _chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion,
            new AuthenticationValues(userNameField.text));  
    }

    public void GetReceiver(TMP_InputField receiver)
    {
        _receiver = String.IsNullOrEmpty(receiver.text) ? "" : receiver.text;
    }

    public void SendMessage(TMP_InputField message)
    {
        if (!String.IsNullOrEmpty(message.text))
        {
            if (String.IsNullOrEmpty(_receiver))
            {
                _chatClient.PublishMessage(_roomName, message.text);
            }
            else
            {
                _chatClient.SendPrivateMessage(_receiver, message.text);
            }

            message.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        _chatClient.Service();
    }
    
    public void OnConnected()
    {
        loginForm.SetActive(false);
        chatForm.SetActive(true);
        
        _chatClient.Subscribe(new string[]{ _roomName });
        _chatClient.SetOnlineStatus(ChatUserStatus.Online);
        print("Connected");
    }
    
    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for(int i = 0; i < senders.Length; i++) {
            chatMessages.text = chatMessages.text + "\n"
                                                  + senders[i] + ": "
                                                  + messages[i];
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        chatMessages.text = chatMessages.text + "\n"
                                              + "(Private) " + sender + ": "
                                              + message ;
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        //_chatClient.PublishMessage(_roomName, "Joined");
    }
    
    public void OnChatStateChange(ChatState state) { }
    public void OnStatusUpdate(string user, int status, bool gotMessage, object message) { }
    public void OnUnsubscribed(string[] channels) { }
    public void OnUserSubscribed(string channel, string user) { }
    public void OnUserUnsubscribed(string channel, string user) { }
    public void DebugReturn(DebugLevel level, string message) { }
    public void OnDisconnected() { }
}
