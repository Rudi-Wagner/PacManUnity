using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelLogic : MonoBehaviour
{
    public Transform tunnelSpawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Set coordinates to the opposite side of game field
        Vector3 position = this.tunnelSpawn.position;
        //dont change z pos
        position.z = other.transform.position.z;
        other.transform.position = position;
    }
}
