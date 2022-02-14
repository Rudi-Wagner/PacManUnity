using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHomeBehavior : GhostBehavior
{
    public Transform inside;
    public Transform outside;
  
    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(ExitProcess());
        }
        
    }

    private IEnumerator ExitProcess()
    {
        this.ghost.movement.SetDirection(Vector2.up, true);
        this.ghost.movement.rigidbody.isKinematic = true;
        this.ghost.movement.enabled = false;

        Vector3 pos = this.transform.position;
        float dur  = 0.5f;
        float elapsed = 0.0f;

        while (elapsed < dur)
        {
            Vector3 newPosition = Vector3.Lerp(pos, this.inside.position, elapsed / dur);
            newPosition.z = pos.z;
            this.ghost.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0.0f;

        while (elapsed < dur)
        {
            Vector3 newPosition = Vector3.Lerp(pos, this.outside.position, elapsed / dur);
            newPosition.z = pos.z;
            this.ghost.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        this.ghost.movement.SetDirection(Vector2.left, true);
        this.ghost.movement.rigidbody.isKinematic = false;
        this.ghost.movement.enabled = true;
    }
}
