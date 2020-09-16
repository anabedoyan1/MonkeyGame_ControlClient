using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] Text teamTextLobby, roleTextLobby, teamTextControl, roleTextControl;

    public void Start()
    {
        DontDestroyOnLoad(this);
        ControlManager.onDataLoaded += ShowInfo;
    }
    public void ShowInfo()
    {
        teamTextLobby.text = ControlManager._instance.team + " team";
        roleTextLobby.text = ControlManager._instance.role;
        teamTextControl.text = ControlManager._instance.team + " team";
        roleTextControl.text = ControlManager._instance.role;
    }    
}
