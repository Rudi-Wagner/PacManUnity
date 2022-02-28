using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public PacmanLogic pacman;
    public Transform pellets;
    public SpecialFoodLogic specialFood;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public GameObject startButton;

    public int round { get; private set; } = 0;
    public int bestRound { get; private set; } = 0;
    public int ghostMultiplier { get; private set; } = 1;
    public float mainSpeedMult = 0.5f;
    public int score { get; private set; }
    public int highscore { get; private set; }
    public int lives = 0;
    public bool immortal = false;

    private Scene scene;
    
    private void Start()
    {
        this.pacman.gameObject.SetActive(false);

        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }

        foreach (Transform pellet in this.pellets) 
        {
            pellet.gameObject.SetActive(false);
        }
        this.scene = SceneManager.GetActiveScene();
        this.bestRound = PlayerPrefs.GetInt(scene.name + "BestRound");
        this.highscore = PlayerPrefs.GetInt(scene.name + "HighScore");
        this.highscoreText.text = "Highscore: " + this.highscore.ToString();
        this.gameOverText.text = "Start a new Game!";
    }

    public void Update()
    {
        if(lives <= 0)
        {
            this.startButton.SetActive(true);
        }
    }

    public void NewGame()
    {
        this.startButton.SetActive(false);
        this.mainSpeedMult = 0.5f;
        this.round = 0;
        SetScore(0);
        SetLives(3);
        NewRound();
        checkForBestRound();
    }

    private void NewRound()
    {
        this.round++;
        this.roundText.text = "Round: " + round;
        foreach (Transform pellet in this.pellets) 
        {
            pellet.gameObject.SetActive(true);
        }
        this.mainSpeedMult += 0.5f;
        ResetState();
    }

    public void GhostEaten(Ghost ghost)
    {
        int points = ghost.points * this.ghostMultiplier;
        SetScore(this.score + points);

        this.ghostMultiplier++;
    }

    public void PacmanEaten()
    {
        if (!immortal)
        {
            this.pacman.deathAnimation();
            this.gameOverText.text = "DIED!";
            SetLives(this.lives - 1);

            if (this.lives > 0) 
            {
                Invoke(nameof(ResetState), 2.0f);
            }
            else
            {
                this.gameOverText.text = "GAME OVER!";
                for (int i = 0; i < this.ghosts.Length; i++)
                {
                    this.ghosts[i].gameObject.SetActive(false);
                }
                foreach (Transform pellet in this.pellets) 
                {
                    pellet.gameObject.SetActive(false);
                }
            }
        }
    }

    private void ResetState()
    {
        this.pacman.ResetState();
        this.gameOverText.text = "";
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].Reset();
        }
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        string txt = "Lives: ";
        for(int i = 0; i < this.lives; i++)
        {
            txt += "<sprite=0> ";
        }
        this.livesText.text = txt;
    }

    private void SetScore(int score)
    {
        this.score = score;
        this.scoreText.text = "Score: " + score.ToString();
    }


    public void eatPellet(PelletLogic pellet)
    {
        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.points);
        checkForHighScore();

        //Check if round is finished 
        if(!remainingPellets())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 5.0f);
        }
    }

    private bool remainingPellets()
    {//Check if there are remaining pellets to eat.
        foreach (Transform pellet in this.pellets) 
        {
            if(pellet.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    public void eatPowerUp(PowerUp powerUp)
    {
        eatPellet(powerUp);
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].flee.Enable(5.0f);
        }
    }

    public void eatSpecialFood(SpecialFoodLogic food)
    {
        food.gameObject.SetActive(false);
        SetScore(this.score + food.points);
        checkForHighScore();
        Invoke(nameof(respawnFood), 100.0f);
    }

    private void checkForHighScore()
    {
        //Check for Highscore
        if(this.score > this.highscore)
        {
            this.highscore = this.score;
            this.highscoreText.text = "Highscore: " + this.highscore.ToString();
        }

        //Check highest Score
        if(this.highscore > PlayerPrefs.GetInt("ClassicSceneHighScore") || this.highscore > PlayerPrefs.GetInt("AdvancedSceneHighScore") )
        {
            PlayerPrefs.SetInt("MenuHighScore", highscore);
        }

        PlayerPrefs.SetInt(scene.name + "HighScore", highscore);
    }

    private void checkForBestRound()
    {
        if(this.round > this.bestRound)
        {
            this.bestRound = this.round;
        }

        //Check highest Score
        if(this.bestRound > PlayerPrefs.GetInt("ClassicSceneBestRound") || this.bestRound > PlayerPrefs.GetInt("AdvancedSceneBestRound") )
        {
            PlayerPrefs.SetInt("MenuBestRound", bestRound);
        }

        PlayerPrefs.SetInt(scene.name + "BestRound", bestRound);
    }

    private void respawnFood()
    {
        specialFood.gameObject.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}