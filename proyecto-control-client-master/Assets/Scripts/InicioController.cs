﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicioController : MonoBehaviour
{
    Network networkController;

    void Start()
    {
        networkController = GameObject.Find("SocketIO").GetComponent<Network>();
        networkController.onConnectedToServer += OnConnectedToServer;
        networkController.onJoinedRoom += OnJoinedRoom;
        networkController.ConnectedToServer();
    }

  

    void OnConnectedToServer(string mensagge)
    {
        Button btnEntrar = GameObject.Find("BtnEntrar").GetComponent<Button>();
        InputField txtInputField = GameObject.Find("TxtRoomCode").GetComponent<InputField>();

        btnEntrar.interactable = true;
        txtInputField.interactable = true;
    }
    void OnJoinedRoom(bool state)
    {
        if (state)
        {
            //gameObject.SendMessage("LoadScene", 1, SendMessageOptions.RequireReceiver);
            ControlManager._instance.CanvasInicio.SetActive(false);
            ControlManager._instance.CanvasInLobby.SetActive(true);
        }
        else
            Debug.Log("Join Room Failed");
    }

    public void JoinRoom()
    {
        InputField txtInputField = GameObject.Find("TxtRoomCode").GetComponent<InputField>();
        networkController.JoinRoom(txtInputField.text);
    }
}
