using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    public MenuGhost ghost;
    public MenuPacMan pacman;
    public MenuSpecialFruit specialFood;

    //Randomly starts a short animation in the menu/settings screen

    private void Start()
    {
        this.specialFood.gameObject.SetActive(false);
        Invoke(nameof(starting), 5.0f + Random.Range(10.0f, 20.0f));
    }

    public void starting()
    {
        //A ghost chasing pacman to the right and spawn a food item to eat
        float randomY = Random.Range(-12.0f, 12.0f);
        this.ghost.Reset(randomY);
        this.pacman.Reset(randomY);
        this.specialFood.Reset(randomY);
        this.ghost.startChase();
        this.pacman.startChase();
        Invoke(nameof(ending), 10.0f + Random.Range(10.0f, 20.0f));
    }

    public void ending()
    {
        //Pacman chasing a ghost to the left
        this.ghost.transform.position = new Vector3(50, -5, 0);
        this.pacman.transform.position = new Vector3(60, -5, 0);
        this.ghost.endChase();
        this.pacman.endChase();
        Invoke(nameof(starting), 10.0f + Random.Range(10.0f, 20.0f));
    }
}
