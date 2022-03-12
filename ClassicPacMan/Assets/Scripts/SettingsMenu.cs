using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public int controlMode { get; private set; }
    public Toggle joystickToggle;
    public Toggle arrowKeysToggle;
    private int resetCNT = 0;
    public TextMeshProUGUI resetText;

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

    public void ResetData()
    {
        resetCNT++;
        if (resetCNT >= 2)
        {
            PlayerPrefs.DeleteAll();
            resetCNT = 0;
            this.resetText.text = "Done! No more Data!";
            CancelInvoke();
            Invoke(nameof(ResetText), 3.0f);
        }
        else
        {
            this.resetText.text = "Click again, if you are sure!";
            Invoke(nameof(ResetText), 3.0f);
        }
    }

    private void ResetText()
    {
        this.resetText.text = "Reset Game Data";
    }
}
