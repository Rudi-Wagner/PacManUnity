using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEyesLogic : MonoBehaviour
{
    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;

    public SpriteRenderer render { get; private set;}
    public MovementLogic movement { get; private set;}

    private void Awake()
    {
        this.render = GetComponent<SpriteRenderer>();
        this.movement = GetComponentInParent<MovementLogic>();
    }

    //Lets the goes look at the player
    void Update()
    {
        if (this.movement.direction == Vector2.up) {
            this.render.sprite = this.up;
        }
        else if (this.movement.direction == Vector2.down) {
            this.render.sprite = this.down;
        }
        else if (this.movement.direction == Vector2.left) {
            this.render.sprite = this.left;
        }
        else if (this.movement.direction == Vector2.right) {
            this.render.sprite = this.right;
        }
    }
}
