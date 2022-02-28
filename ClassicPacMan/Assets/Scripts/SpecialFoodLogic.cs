using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialFoodLogic : MonoBehaviour
{
    public int points = 200;

    protected void OnTriggerEnter2D(Collider2D other)
    {//Only pacman is allowed to "collide" / eat the pelllets
        if (other.gameObject.layer == LayerMask.NameToLayer("pacman")) {
            destroyPellet();
        }
    }

    protected virtual void destroyPellet()
    {
        FindObjectOfType<GameManager>().eatSpecialFood(this);
    }
}
