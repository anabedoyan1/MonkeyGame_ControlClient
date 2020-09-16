using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlInput : MonoBehaviour
{
    Network networkController;
    Button leftBtn;
    Button rightBtn;
    ControlUI controlUI;
    // Start is called before the first frame update
    void Start()
    {
        networkController = GameObject.Find("SocketIO").GetComponent<Network>();
        leftBtn = GameObject.Find("LeftButton").GetComponent<Button>();
        rightBtn = GameObject.Find("RightButton").GetComponent<Button>();
        controlUI = GetComponent<ControlUI>();
        leftBtn.onClick.AddListener(delegate { GetInput("LEFT"); });
        rightBtn.onClick.AddListener(delegate { GetInput("RIGHT"); });
        controlUI.RightOff.gameObject.SetActive(false);
    }
   
    public void GetInput(string _command)
    {
        if (_command == "RIGHT")
        {
            Debug.Log("Right");
            controlUI.RightOff.gameObject.SetActive(false);
            controlUI.LeftOff.gameObject.SetActive(true);
        }
        if (_command == "LEFT")
        {
            Debug.Log("Left");
            controlUI.RightOff.gameObject.SetActive(true);
            controlUI.LeftOff.gameObject.SetActive(false);
        }
        networkController.SendInput(_command);

    }
}
