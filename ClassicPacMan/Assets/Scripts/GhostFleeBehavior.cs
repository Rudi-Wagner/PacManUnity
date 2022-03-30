using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFleeBehavior : GhostBehavior
{
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer blue;
    public SpriteRenderer white;

    public bool eaten { get; private set;}

    //Sets the ghosts in the "fleeing" state
    //During this state the gohsts move away from the player
    //The state is only a short time active, then it switches back to normal

    public new void Enable(float dur)
    {
        base.Enable(dur);
        this.body.enabled = false;
        this.eyes.enabled = false;
        this.blue.enabled = true;
        this.white.enabled = false;

        Invoke(nameof(Blink), dur / 2.0f);
    }

    public new void Disable()
    {
        base.Disable();

        this.body.enabled = true;
        this.eyes.enabled = true;
        this.blue.enabled = false;
        this.white.enabled = false;
    }

    private void Eaten()
    {
        //Change ghost sprites
        this.eaten = true;
        Vector3 pos = this.ghost.home.inside.position;
        pos.z = this.ghost.transform.position.z;
        this.ghost.transform.position = pos;
        this.ghost.home.Enable(this.duration + Random.Range(0, 10));

        this.body.enabled = false;
        this.eyes.enabled = true;
        this.blue.enabled = false;
        this.white.enabled = false;
    }

    private void Blink()
    {
        //Blink to give a visual cue to the player, that the phase is almost over
        if (!this.eaten)
        {
            this.blue.enabled = false;
            this.white.enabled = true; 
            this.white.GetComponent<AnimatedSprite>().Restart();
        }
    }

    private void OnEnable()
    {
        this.ghost.movement.speedMult = 0.5f;
        this.eaten = false;
    }

    private void OnDisable()
    {
        this.ghost.movement.speedMult = this.ghost.movement.manager.mainSpeedMult;
        this.eaten = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        NodeLogic node = other.GetComponent<NodeLogic>();

        if (node != null && this.enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach (Vector2 allowedDirection in node.allowedDirection)
            {
                Vector3 newPosition = this.transform.position + new Vector3(allowedDirection.x, allowedDirection.y);
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = allowedDirection;
                    maxDistance = distance;
                }
            }

            this.ghost.movement.SetDirection(direction);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("pacman"))
        {
            if (this.enabled)
            {
                Eaten();
            }
        }
    }
}
