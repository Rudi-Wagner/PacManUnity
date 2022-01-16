using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public PacmanLogic pacman;
    public Transform pellets;

    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives = 3;

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKey) {
            NewGame();
        }
    }

    private void NewGame()
    {
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
    }

    private void SetScore(int score)
    {
        this.score = score;
    }


    public void eatPellet(PelletLogic pellet)
    {
        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.points);
        //Check if round is finished 
    }

    public void eatPowerUp(PowerUp powerUp)
    {
        eatPellet(powerUp);

        //change ghost
    }
}
