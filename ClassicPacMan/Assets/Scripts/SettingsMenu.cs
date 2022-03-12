using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public int controlMode { get; private set; }
    public Toggle joystickToggle;
    public Toggle arrowKeysToggle;

    private void Start()
    {
        this.controlMode = PlayerPrefs.GetInt("Controls");
        if(this.controlMode == 0)
        {//Load Joystick
            this.joystickToggle.isOn = true;
            this.arrowKeysToggle.isOn = false;
        }else if(this.controlMode == 1)
        {//Load Arrow Keys
            this.joystickToggle.isOn = false;
            this.arrowKeysToggle.isOn = true;
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToggleJoystick()
    {
        PlayerPrefs.SetInt("Controls", 0);
    }

    public void ToggleArrowKeys()
    {
        PlayerPrefs.SetInt("Controls", 1);
    }
}
