using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeysController : MonoBehaviour
{
    private Vector2 input;
    private int currentKonami = 0;
    public GameManager manager;
    public PacmanLogic pacman;

    //Set Vector accroding to input
    //Also check for secret KonamiCode input

    public void up()
    {
        this.input = new Vector2(0, 1);
        this.pacman.arrowKeysInput = this.input;
        KonamiCode("up");
    }

    public void down()
    {
        this.input = new Vector2(0, -1);
        this.pacman.arrowKeysInput = this.input;
        KonamiCode("down");
    }

    public void left()
    {
        this.input = new Vector2(-1, 0);
        this.pacman.arrowKeysInput = this.input;
        KonamiCode("left");
    }

    public void right()
    {
        this.input = new Vector2(1, 0);
        this.pacman.arrowKeysInput = this.input;
        KonamiCode("right");    
    }

    private void KonamiCode(string direction)
    {
        //Little secret to find
        //Konami code: up, up, down, down, left, right, left, right
        string[] check = new string[8]{"up", "up", "down", "down", "left", "right", "left", "right"};
        if (direction != check[currentKonami])
        {
            currentKonami = 0;
            return;
        }
        if (currentKonami == 7)
        {
            if (this.manager.immortal)
            {
                this.manager.immortal = false;
            }
            else
            {
                this.manager.immortal = true;
            }
            currentKonami = 0;
        }
        currentKonami++;
    }
}
