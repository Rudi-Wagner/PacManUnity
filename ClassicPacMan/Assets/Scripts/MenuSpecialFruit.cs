using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpecialFruit : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer { get; private set; }
    public int easterEggNum = 4;

    //Food from the menu animation

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
        this.spriteRenderer.sprite = this.sprites[Random.Range(0, getEasterEggs())];
    }

    private int getEasterEggs()
    {
        //Allow more images for the food item, when reached a certain Highscore
        int highscore = PlayerPrefs.GetInt("MenuHighScore");
        while (highscore >= 3000)
        {
            highscore -= 3000;
            easterEggNum++;
        }
        if (easterEggNum > sprites.Length)
        {
            easterEggNum = sprites.Length;
        }
        return easterEggNum;
    }

    private void destroyPellet()
    {
        this.gameObject.SetActive(false);
    }

    public void Reset(float randomY)
    {
        this.gameObject.SetActive(true);
        this.transform.position = new Vector3(0, randomY, 0);
    }
}
