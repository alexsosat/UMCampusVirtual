using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChatBehaviour : MonoBehaviour
{
    private PhotonView _view;
    private TMP_InputField _chatInput;
    private Button _chatSendButton;
    
    
    private BasicBehaviour _moveBehaviour;
    private ThirdPersonOrbitCamBasic _camBehaviour;
    
    private bool _chatEnabled = false;
    

    private void Awake()
    {
        _view = GetComponent<PhotonView>();
        _moveBehaviour = GetComponent<BasicBehaviour>();
        _camBehaviour = GetComponentInChildren<ThirdPersonOrbitCamBasic>();
        FindChat();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (_view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Return) && _chatEnabled)
            {
                FocusChat(false,null);
                _chatSendButton.onClick.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.Return) && !_chatEnabled)
            {
                FocusChat(true,_chatInput.gameObject);
            }
        }
    }

    private void FocusChat(bool enable, GameObject selectedGameObject)
    {
        _chatEnabled = enable;
        Cursor.lockState =  enable?CursorLockMode.None:CursorLockMode.Locked;
        _moveBehaviour.canWalk = !enable;
        _camBehaviour.enabled = !enable;
        EventSystem.current.SetSelectedGameObject(selectedGameObject, null);
    }

    private void FindChat()
    {
        GameObject chatObject = GameObject.Find("ChatManager");
        Transform panelTransform = chatObject.transform.GetChild(0).GetChild(0);
        Transform chatUI = panelTransform.Find("ChatRoom");
        _chatSendButton = chatUI.Find("SendButton").GetComponent<Button>();
        _chatInput = chatUI.Find("InputField (TMP)").GetComponent<TMP_InputField>();
    }
}
