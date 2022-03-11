using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public Toggle joystickToggle;
    public Toggle arrowKeysToggle;

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToggleJoystick()
    {
        if (this.joystickToggle.isOn)
        {
            this.arrowKeysToggle.isOn = false;
        }
        Debug.Log("JOYSTICK " + this.joystickToggle.isOn);
    }

    public void ToggleArrowKeys()
    {
        if (this.arrowKeysToggle.isOn)
        {
            this.joystickToggle.isOn = false;
        }
        Debug.Log("ARROWKEYS " + this.arrowKeysToggle.isOn);
    }
}
