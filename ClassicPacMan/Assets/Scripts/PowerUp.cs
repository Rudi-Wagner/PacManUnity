using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : PelletLogic
{
    public float duration = 8.0f;

    protected override void destroyPellet()
    {
        FindObjectOfType<GameManager>().eatPowerUp(this);
    }
}
