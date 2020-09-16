using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySocketIO;
using UnitySocketIO.Events;

public delegate void MessageDelegate(string mensagge);
public delegate void BoolDelegate(bool state);

public delegate void CharacterDelegate(string team, string role);

public class Network : MonoBehaviour
{

    SocketIOController socket;

    public event MessageDelegate onConnectedToServer;
    public event BoolDelegate onJoinedRoom;
    public event BoolDelegate onGameReady;
    public event CharacterDelegate onCharacterArrived;


    private void Awake()
    {
    }
    void Start()
    {
        socket = gameObject.GetComponent<SocketIOController>();        
        DontDestroyOnLoad(this.gameObject);
    }

    public void ConnectedToServer()
    {

        socket.On("onConnection", OnConnection);
        socket.On("joinedToRoom", JoinedToRoom);
        socket.On("gameReady", GameReady);
        socket.On("playerCharacterization", PlayerCharacterization);
        socket.Connect();

    }

    

    void OnConnection(SocketIOEvent evt)
    {
        JsonData data = JsonUtility.FromJson<JsonData>(evt.data);
        Debug.Log(data.message);
        onConnectedToServer(data.message);

    }

    void JoinedToRoom(SocketIOEvent evt)
    {
        JsonData data = JsonUtility.FromJson<JsonData>(evt.data);
        onJoinedRoom(data.state);
    }

    public void JoinRoom(string room)
    {
        JsonData data = new JsonData();
        data.room = room;
        socket.Emit("joinRoom", JsonUtility.ToJson(data));
    }

    public void PlayerCharacterization(SocketIOEvent evt)
    {
        PlayerCharacterData data = JsonUtility.FromJson<PlayerCharacterData>(evt.data);
        string team = data.team;
        string role = data.role;
        Debug.Log(data.team + " " + data.role);
        ControlManager._instance.team = team;
        ControlManager._instance.role = role;
        ControlManager.onDataLoaded?.Invoke();
        //onCharacterArrived(team, role);

    }

    public void SetReady()
    {
        socket.Emit("playerReady");
    }

    void GameReady(SocketIOEvent evt)
    {
        JsonData data = JsonUtility.FromJson<JsonData>(evt.data);
        onGameReady(data.state);
    }
    
    public void SendInput(string command)
    {
        PlayerInputData data = new PlayerInputData();
        data.command = command;
        socket.Emit("playerInput", JsonUtility.ToJson(data));
    }    

}

class JsonData
{
    public string message;
    public string room;
    public bool state;
}
public class PlayerInputData
{
    public string command;
}

public class PlayerCharacterData
{
    public string team;
    public string role;
    public string playerId;
    public string nickname;
}


