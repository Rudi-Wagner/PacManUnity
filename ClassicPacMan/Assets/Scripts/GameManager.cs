using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public PacmanLogic pacman;
    public Transform pellets;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives = 3;
    
    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.GetKeyDown(KeyCode.Space)) {
            NewGame();
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        foreach (Transform pellet in this.pellets) {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        this.pacman.ResetState();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        string txt = "Lives: ";
        for(int i = 0; i < this.lives; i++)
        {
            txt += " <3 ";
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

        //change ghost
    }
}
