using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject classicButton;
    public GameObject advancedButton;

    private void Start()
    {
        
    }

    public void LoadClassic()
    {
        SceneManager.LoadScene("ClassicScene");
    }

    public void LoadAdvanced()
    {
        Debug.Log("NOT IMPLEMENTED!!!");
    }
}
