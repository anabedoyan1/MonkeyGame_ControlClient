using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnReady : MonoBehaviour
{    
    public void PlayerReady()
    {
        ControlManager._instance.SetReady();
    }
    

}
