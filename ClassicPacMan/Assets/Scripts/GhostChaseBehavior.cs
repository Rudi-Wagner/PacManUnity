using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChaseBehavior : GhostBehavior
{
    private void OnTriggerEnter2D(Collider2D othernode)
    {
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

    private void OnDisable()
    {
        this.ghost.roam.Enable();
    }
}
