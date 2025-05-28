using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float Speed, TimeToRevert;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;


    private Rigidbody2D rb;

    private const float IdleState = 0;
    private const float WalkState = 1;
    private const float RevertState = 2;

    private float currentState, currentTimeToRevert;

    void Start()
    {
        currentState = IdleState;
        currentTimeToRevert = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(currentTimeToRevert >= TimeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = RevertState;
        }

        switch (currentState)
        {
            case IdleState:
                currentTimeToRevert += Time.deltaTime;
                break;

            case WalkState:
                rb.velocity = Vector2.right * Speed;
                break;

            case RevertState:
                spriteRenderer.flipX = !spriteRenderer.flipX;
                Speed *= -1;
                currentState = WalkState;
                break;
        }

        animator.SetFloat("Velocity", rb.velocity.magnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
        {
            currentState = IdleState;
        }
    }
}
