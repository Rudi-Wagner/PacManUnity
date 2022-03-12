using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeysController : MonoBehaviour
{
    private Vector2 input;
    public PacmanLogic pacman;

    public void up()
    {
        this.input = new Vector2(0, 1);
        this.pacman.arrowKeysInput = this.input;
    }

    public void down()
    {
        this.input = new Vector2(0, -1);
        this.pacman.arrowKeysInput = this.input;
    }

    public void left()
    {
        this.input = new Vector2(-1, 0);
        this.pacman.arrowKeysInput = this.input;
    }

    public void right()
    {
        this.input = new Vector2(1, 0);
        this.pacman.arrowKeysInput = this.input;
    }
}
