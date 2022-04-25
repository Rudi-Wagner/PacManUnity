using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
