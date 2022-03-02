using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPacMan : MonoBehaviour
{
    public MovementLogic movement { get; private set;}

    private void Awake()
    {
        this.movement = GetComponent<MovementLogic>();
    }

    private void Update()
    {
        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void startChase()
    {
        this.movement.SetDirection(Vector2.right);
    }

    public void endChase()
    {
        this.movement.SetDirection(Vector2.left);
    }

    public void Reset()
    {
        this.movement.SetDirection(Vector2.zero);
        this.transform.position = new Vector3(-50, -5, 0);
    }
}
