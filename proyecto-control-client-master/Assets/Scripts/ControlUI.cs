using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI : MonoBehaviour
{
    [SerializeField] Image leftOff, leftRed, leftBlue, rightRed, rightBlue, rightOff;
    string team;

    public Image LeftOff { get => leftOff; set => leftOff = value; }
    public Image RightOff { get => rightOff; set => rightOff = value; }

    public void Awake()    {
        
        ControlManager.onDataLoaded += ColourControl;
    }
    public void ColourControl()
    {
        if(ControlManager._instance.team == "Blue")
        {
            leftBlue.gameObject.SetActive(true);
            rightBlue.gameObject.SetActive(true);
            leftRed.gameObject.SetActive(false);
            rightRed.gameObject.SetActive(false);
        }
        if (ControlManager._instance.team == "Red")
        {
            leftBlue.gameObject.SetActive(false);
            rightBlue.gameObject.SetActive(false);
            leftRed.gameObject.SetActive(true);
            rightRed.gameObject.SetActive(true);
        }
    }
}
