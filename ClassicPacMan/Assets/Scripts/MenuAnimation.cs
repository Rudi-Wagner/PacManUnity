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
        this.specialFood.transform.position = new Vector3(0, -5, 0);
        Invoke(nameof(starting), 5.0f + Random.Range(10.0f, 20.0f));
    }

    public void starting()
    {
        this.specialFood.gameObject.SetActive(true);
        this.ghost.Reset();
        this.pacman.Reset();
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
