using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletLogic : MonoBehaviour
{
    public int points = 10;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        //Only pacman is allowed to "collide" / eat the pelllets
        if (other.gameObject.layer == LayerMask.NameToLayer("pacman")) {
            destroyPellet();
        }
    }

    protected virtual void destroyPellet()
    {
        FindObjectOfType<GameManager>().eatPellet(this);
    }
}
