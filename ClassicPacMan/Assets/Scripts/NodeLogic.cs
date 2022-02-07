using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLogic : MonoBehaviour
{
    public List<Vector2> allowedDirection { get; private set;}
    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        this.allowedDirection = new List<Vector2>();
        checkValid(Vector2.up);
        checkValid(Vector2.down);
        checkValid(Vector2.left);
        checkValid(Vector2.right);
    }

    private void checkValid(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, this.wallLayer);
        if (hit.collider == null) 
        {
            this.allowedDirection.Add(direction);
        }
    }
}
