using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRoamBehavior : GhostBehavior
{
    //Randomly choose the next direction to go (exception is right back where the gohst originally came from)

    private void OnTriggerEnter2D(Collider2D othernode)
    {
        NodeLogic node = othernode.GetComponent<NodeLogic>();
        if (node != null && this.enabled && !this.ghost.flee.enabled)
        {
            int i = Random.Range(0, node.allowedDirection.Count);
            if (node.allowedDirection[i] == -this.ghost.movement.direction)
            {
                i++;
                if(i >= node.allowedDirection.Count)
                {
                    i= 0;
                }
            }
            this.ghost.movement.SetDirection(node.allowedDirection[i]);
        }
    }

    private void OnDisable()
    {
        this.ghost.chase.Enable();
    }
}
