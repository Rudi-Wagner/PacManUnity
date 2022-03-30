using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadControls : MonoBehaviour
{
    public int controlMode { get; private set; }
    public GameObject joyStick;
    public GameObject arrowKeys;

    //Switch displayed controle type according to the settings

    private void Start()
    {
        this.controlMode = PlayerPrefs.GetInt("Controls");

        if(this.controlMode == 0)
        {//Load Joystick
            this.joyStick.gameObject.SetActive(true);
            this.arrowKeys.gameObject.SetActive(false);
        }else if(this.controlMode == 1)
        {//Load Arrow Keys
            this.joyStick.gameObject.SetActive(false);
            this.arrowKeys.gameObject.SetActive(true);
        }

    }
}
