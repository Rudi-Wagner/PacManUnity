using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int points = 200;
    public MovementLogic movement { get; private set;}
    public GhostHomeBehavior home { get; private set;}
    public GhostChaseBehavior chase { get; private set;}
    public GhostRoamBehavior roam { get; private set;}
    public GhostFleeBehavior flee { get; private set;}
    public GhostBehavior initial;
    public Transform target;

    private void Start()
    {
        Reset();
    }
    private void Awake()
    {
        this.movement = GetComponent<MovementLogic>();
        this.home = GetComponent<GhostHomeBehavior>();
        this.chase = GetComponent<GhostChaseBehavior>();
        this.roam = GetComponent<GhostRoamBehavior>();
        this.flee = GetComponent<GhostFleeBehavior>();
    }

    public void Reset()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetMovement();

        this.flee.Disable();
        this.chase.Disable();
        this.roam.Enable();
        if(this.home != this.initial)
        {
            this.home.Disable();
        }

        if (this.initial != null)
        {
            this.initial.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("pacman"))
        {
            if (this.flee.enabled)
            {
                FindObjectOfType<GameManager>().GhostEaten(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PacmanEaten();
            }
        }
    }
}
