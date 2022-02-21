using UnityEngine;
using UnityEngine.InputSystem;

public class PacmanLogic : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public new Collider2D collider { get; private set; }
    public MovementLogic movement { get; private set; }
    public Vector2 joyInput { get; private set; }

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.collider = GetComponent<Collider2D>();
        this.movement = GetComponent<MovementLogic>();
    }

    private void Update()
    {
        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    private void OnMove(InputValue value)
    {
        joyInput = value.Get<Vector2>();

        //Get Vector2 to move (Up, Down, Left, Right)
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
    }

    public void ResetState()
    {
        this.enabled = true;
        this.spriteRenderer.enabled = true;
        this.collider.enabled = true;
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = new Vector3(0, -8.5f, -5);
    }
}