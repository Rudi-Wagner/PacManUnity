using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class PacmanLogic : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public new Collider2D collider { get; private set; }
    public MovementLogic movement { get; private set; }
    public InputController input { get; private set; }
    public Vector2 arrowKeysInput;

    public AnimatedSprite normal;
    public AnimatedSprite death;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.collider = GetComponent<Collider2D>();
        this.movement = GetComponent<MovementLogic>();
        this.input = new InputController();
    }

    private void Update()
    {
        //Movement input from the player
        Vector2 joyInput = this.input.Player.Move.ReadValue<Vector2>();
        //Get Vector2 to move (Up, Down, Left, Right)
        if(PlayerPrefs.GetInt("Controls") == 0)
        {//Use Joystick
            if(joyInput.y >= 0.5f)
            {
                this.movement.SetDirection(Vector2.up);
            } else if(joyInput.y <= -0.5f)
            {
                this.movement.SetDirection(Vector2.down);
            } else if(joyInput.x > 0.5f)
            {
                this.movement.SetDirection(Vector2.right);
            } else if(joyInput.x < -0.5f)
            {
                this.movement.SetDirection(Vector2.left);
            }
        } else if(PlayerPrefs.GetInt("Controls") == 1)
        {//Use arrow keys
            if(arrowKeysInput.y == 1)  
            {
                this.movement.SetDirection(Vector2.up);
            } else if(arrowKeysInput.y == -1)
            {
                this.movement.SetDirection(Vector2.down);
            } else if(arrowKeysInput.x == 1f)
            {
                this.movement.SetDirection(Vector2.right);
            } else if(arrowKeysInput.x == -1f)
            {
                this.movement.SetDirection(Vector2.left);
            }
        }
        

        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    

    public void ResetState()
    {
        //Reset pacman to a "normal" state
        this.movement.SetDirection(Vector2.zero);
        this.enabled = true;
        this.spriteRenderer.enabled = true;
        this.collider.enabled = true;
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = new Vector3(0, -8.5f, -5);
        if (SceneManager.GetActiveScene().name == "AdvancedScene")
        {
            this.gameObject.transform.position = new Vector3(0, -6.5f, -5);
        }
    }

    public void deathAnimation()
    {
        //Play death animation after collision with a ghost
        this.collider.enabled = false;
        this.movement.SetDirection(Vector2.zero);
        this.transform.rotation = Quaternion.AngleAxis(90 * Mathf.Rad2Deg, Vector3.forward);
        this.normal.enabled = false;
        this.normal.doLoop = false;
        this.death.enabled = true;
        this.death.Restart();
        this.death.doLoop = false;
        this.movement.enabled = false;
        Invoke(nameof(die), 1.0f);
    }

    private void die()
    {
        //Disable player controls
        this.gameObject.SetActive(false);
        this.collider.enabled = true;
        this.normal.enabled = true;
        this.normal.doLoop = true;
        this.death.enabled = false;
        this.death.doLoop = false;
        this.movement.enabled = true;
    }

    private void OnEnable()
    {
        this.input.Enable();
        this.movement.speedMult = this.movement.manager.mainSpeedMult;
    }

    private void OnDisable()
    {
        this.input.Disable();
    }
}