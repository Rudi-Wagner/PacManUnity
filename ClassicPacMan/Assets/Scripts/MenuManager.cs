using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject classicButton;
    public GameObject advancedButton;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI highscoreText;

    public int highscore { get; private set; }
    public int bestRound { get; private set; }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        this.highscore = PlayerPrefs.GetInt("MenuHighScore");
        this.highscoreText.text = "Best Highscore: " + this.highscore.ToString();

        this.bestRound = PlayerPrefs.GetInt("MenuBestRound");
        this.roundText.text = "Best Round: " + this.bestRound.ToString();
    }
    
    public void LoadClassic()
    {
        SceneManager.LoadScene("ClassicScene");
    }

    public void LoadAdvanced()
    {
        SceneManager.LoadScene("AdvancedScene");
    }
}
