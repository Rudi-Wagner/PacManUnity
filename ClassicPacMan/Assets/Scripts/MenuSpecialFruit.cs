using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpecialFruit : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer { get; private set; }

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("pacman")) {
            destroyPellet();
        }
    }

    public void OnEnable()
    {
        this.spriteRenderer.sprite = this.sprites[Random.Range(0, this.sprites.Length)];
    }

    private void destroyPellet()
    {
        this.gameObject.SetActive(false);
    }
}
