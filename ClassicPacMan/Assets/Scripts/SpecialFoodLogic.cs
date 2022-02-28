using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialFoodLogic : MonoBehaviour
{
    public int points = 200;
    public Sprite[] sprites = new Sprite[0];
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

    protected virtual void destroyPellet()
    {
        FindObjectOfType<GameManager>().eatSpecialFood(this);
    }
}
