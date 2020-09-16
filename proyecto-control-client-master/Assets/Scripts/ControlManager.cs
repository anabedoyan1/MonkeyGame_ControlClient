using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlManager : MonoBehaviour
{
    Network networkController;
    [HideInInspector] public string team, role;

    public static ControlManager _instance = null;

    public static Action onDataLoaded;
    [SerializeField] GameObject canvasInicio, canvasInLobby, canvasControl;

    public GameObject CanvasInicio { get => canvasInicio; set => canvasInicio = value; }
    public GameObject CanvasControl { get => canvasControl; set => canvasControl = value; }
    public GameObject CanvasInLobby { get => canvasInLobby; set => canvasInLobby = value; }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
        networkController = GameObject.Find("SocketIO").GetComponent<Network>();        
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Start()
    {        
        networkController.onGameReady += OnGameReady;
        canvasInicio.gameObject.SetActive(true);
        //networkController.onCharacterArrived += OnSetCharacter;
    }

    public void SetReady()
    {
        networkController.SetReady();
    }
    private void OnGameReady(bool state)
    {
        //this.gameObject.SendMessage("LoadScene", 2, SendMessageOptions.RequireReceiver);
        Debug.Log("Game ready");
        canvasInLobby.SetActive(false);
        canvasControl.SetActive(true);
        onDataLoaded?.Invoke();
    }
    //public void OnSetCharacter(string _team, string _role)
    //{
    //    this.team = _team;
    //    this.role = _role;
    //    onDataLoaded?.Invoke();
    //    Debug.Log("Soy control Manager: "+ team + " " + role);
    //}

}
