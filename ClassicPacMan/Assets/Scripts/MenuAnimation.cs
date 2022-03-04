using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    public MenuGhost ghost;
    public MenuPacMan pacman;
    public MenuSpecialFruit specialFood;

    private void Start()
    {
        this.specialFood.gameObject.SetActive(false);
        Invoke(nameof(starting), 5.0f + Random.Range(10.0f, 20.0f));
    }

    public void starting()
    {
        float randomY = Random.Range(-17.0f, 17.0f);
        this.ghost.Reset(randomY);
        this.pacman.Reset(randomY);
        this.specialFood.Reset(randomY);
        this.ghost.startChase();
        this.pacman.startChase();
        Invoke(nameof(ending), 10.0f + Random.Range(10.0f, 20.0f));
    }

    public void ending()
    {
        this.ghost.transform.position = new Vector3(50, -5, 0);
        this.pacman.transform.position = new Vector3(55, -5, 0);
        this.ghost.endChase();
        this.pacman.endChase();
        Invoke(nameof(starting), 10.0f + Random.Range(10.0f, 20.0f));
    }
}
