using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChaseBehavior : GhostBehavior
{
    public PacmanLogic pacman;
    public bool orangeChase = true;
    public GameManager manager;

    private void OnTriggerEnter2D(Collider2D othernode)
    {
        //Set Ghost behaviour according to ghost type/colour
        switch (this.ghost.type)
        {
            case "red":
                calculateRED(othernode);
                break;
            
            case "blue":
                calculateBLUE(othernode);
                break;
        
            case "pink":
                calculatePINK(othernode);
                break;
            
            case "orange":
                calculateORANGE(othernode);
                break;

            default:
                if(!this.ghost.home.enabled)
                {
                    this.ghost.roam.Enable();
                }
                break;
        }
    }

    private void OnDisable()
    {
        this.ghost.roam.Enable();
    }

    private void calculateRED(Collider2D othernode)
    {
        //Red Ghost AI
        //Chases the player directly
        NodeLogic node = othernode.GetComponent<NodeLogic>();
        if (node != null && this.enabled && !this.ghost.flee.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDist = float.MaxValue;
            foreach (Vector2 allowedDirection in node.allowedDirection)
            {
                Vector3 newPos = this.transform.position + new Vector3(allowedDirection.x, allowedDirection.y, 0.0f);
                float dist = (this.ghost.target.position - newPos).sqrMagnitude;
                if (dist < minDist)
                {
                    direction = allowedDirection;
                    minDist = dist;
                }
            }
            this.ghost.movement.SetDirection(direction);
        }
    }

    private void calculateBLUE(Collider2D othernode)
    {
        //Blue Ghost AI
        //Position is calcualted with the player position and the red gjost position
        NodeLogic node = othernode.GetComponent<NodeLogic>();
        if (node != null && this.enabled && !this.ghost.flee.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDist = float.MaxValue;
            foreach (Vector2 allowedDirection in node.allowedDirection)
            {
                Vector3 newPos = this.transform.position + new Vector3(allowedDirection.x, allowedDirection.y, 0.0f);

                //Change target position
                Vector3 target = this.ghost.target.position;
                
                //calculate changed value based on pacman moving direction
                float offsetvalue = 5.0f;
                if (this.pacman.movement.direction == Vector2.up) {
                    target.y += offsetvalue;
                }
                else if (this.pacman.movement.direction == Vector2.down) {
                    target.y -= offsetvalue;
                }
                else if (this.pacman.movement.direction == Vector2.left) {
                    target.x -= offsetvalue;
                }
                else if (this.pacman.movement.direction == Vector2.right) {
                    target.x += offsetvalue;
                }

                Ghost redghost = this.manager.ghosts[0];
                float xDist = target.x - redghost.transform.position.x;
                float yDist = target.y - redghost.transform.position.y;
                target = new Vector3(target.x + xDist, target.y + yDist, 0.0f);

                float dist = (target - newPos).sqrMagnitude;
                if (dist < minDist)
                {
                    direction = allowedDirection;
                    minDist = dist;
                }
            }
            this.ghost.movement.SetDirection(direction);
        }
    }

    private void calculatePINK(Collider2D othernode)
    {
        //Pink Ghost AI
        //Moves in front of the player
        NodeLogic node = othernode.GetComponent<NodeLogic>();
        if (node != null && this.enabled && !this.ghost.flee.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDist = float.MaxValue;
            foreach (Vector2 allowedDirection in node.allowedDirection)
            {
                Vector3 newPos = this.transform.position + new Vector3(allowedDirection.x, allowedDirection.y, 0.0f);

                //Change target position
                Vector3 target = this.ghost.target.position;
                
                //calculate changed value based on pacman moving direction
                float offsetvalue = 5.0f;
                if (this.pacman.movement.direction == Vector2.up) {
                    target.y += offsetvalue;
                }
                else if (this.pacman.movement.direction == Vector2.down) {
                    target.y -= offsetvalue;
                }
                else if (this.pacman.movement.direction == Vector2.left) {
                    target.x -= offsetvalue;
                }
                else if (this.pacman.movement.direction == Vector2.right) {
                    target.x += offsetvalue;
                }

                float dist = (target - newPos).sqrMagnitude;
                if (dist < minDist)
                {
                    direction = allowedDirection;
                    minDist = dist;
                }
            }
            this.ghost.movement.SetDirection(direction);
        }
    }

    private void calculateORANGE(Collider2D othernode)
    {
        //Orange Ghost AI
        //First moves to the player, if close enough it goes away
        NodeLogic node = othernode.GetComponent<NodeLogic>();
        if (node != null && this.enabled && !this.ghost.flee.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDist = float.MaxValue;
            float maxDist = float.MinValue;
            foreach (Vector2 allowedDirection in node.allowedDirection)
            {
                Vector3 newPos = this.transform.position + new Vector3(allowedDirection.x, allowedDirection.y, 0.0f);
                float dist = (this.ghost.target.position - newPos).sqrMagnitude;

                if (dist < minDist && orangeChase)
                {
                    direction = allowedDirection;
                    minDist = dist;
                }
                if (dist > maxDist && !orangeChase)
                {
                    direction = allowedDirection;
                    maxDist = dist;
                }
                if(dist <= 5.0f && orangeChase)
                {
                    orangeChase = !orangeChase;
                }
                if(dist >= 20.0f && !orangeChase)
                {
                    orangeChase = !orangeChase;
                }
            }
            this.ghost.movement.SetDirection(direction);
        }
    }
}
