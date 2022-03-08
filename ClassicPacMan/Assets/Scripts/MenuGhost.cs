using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGhost : MonoBehaviour
{
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer blue;

    public MovementLogic movement { get; private set;}

    private void Awake()
    {
        this.movement = GetComponent<MovementLogic>();
    }

    public void startChase()
    {
        this.movement.SetDirection(Vector2.right);
    }

    public void endChase()
    {
        this.body.enabled = false;
        this.eyes.enabled = false;
        this.blue.enabled = true;
        this.movement.SetDirection(Vector2.left);
    }
    
    public void Reset(float randomY)
    {
        this.body.enabled = true;
        this.eyes.enabled = true;
        this.blue.enabled = false;
        this.movement.SetDirection(Vector2.zero);
        this.transform.position = new Vector3(-60, randomY, 0);
    }
}
