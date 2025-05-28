using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(PlayerMovement))]
[RequireComponent (typeof (Shooter))]
[RequireComponent(typeof(Animator))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;
    private Animator animator;
    private EventBus eventBus;


    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
    public const string JUMP = "Jump";
    public const string FIRE_1 = "Fire1";


    [SerializeField] private UnityEvent EscapePressed;

    [SerializeField] private bool canBeControlled = true;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
        animator = GetComponent<Animator>();

        while (eventBus == null)
        {
            eventBus = FindObjectOfType<EventBus>();
        }
        eventBus?.PlayerDeath.AddListener(BlockPlayerControl);
        eventBus?.BlockPlayerMovement.AddListener(BlockPlayerControl);
        eventBus?.UnblockPlayerMovement.AddListener(UnblockPlayerControl);
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis(HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(JUMP);

        if (canBeControlled && Input.GetButtonDown(FIRE_1))
        {
            shooter.Shoot(horizontalDirection);
            animator.SetTrigger("isQuickAttacking");
        }

        if (canBeControlled)
        {
            playerMovement.Move(horizontalDirection, isJumpButtonPressed);
        }



        if (horizontalDirection == 0)
        {
            animator.SetBool("isRunning", false);
        }

        else if (canBeControlled && Mathf.Abs(horizontalDirection) > 0.000f)
        {
            animator.SetBool("isRunning", true);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            eventBus.EscapePressed.Invoke();
        }
    }

    public void ChangePossibilityControl()
    {
        canBeControlled = !canBeControlled;
    }

    public void BlockPlayerControl()
    {
        canBeControlled = false;
    }

    public void UnblockPlayerControl()
    {
        canBeControlled = true;
    }
}
