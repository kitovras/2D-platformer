using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(AnimationStates))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpOffset;
    [SerializeField] private bool secondJump;

    [Header("Technical fields")]
    [SerializeField] private LayerMask ground;
    [SerializeField] private bool RaycastGrondLeft;
    [SerializeField] private bool RaycastGrondRight;
    [SerializeField] private bool OverlapCircleGround;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundColliderTransform;

    [SerializeField] AnimationCurve curve;
    [SerializeField] float movementSpeed;
    [SerializeField] private float movementSpeedGround;
    [SerializeField] private float movementSpeedAir;

    private Rigidbody2D rb;
    private AnimationStates animationStates;

    private float acceleration;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationStates = GetComponent<AnimationStates>();
    }
    private void FixedUpdate()
    {
        CheckGround();
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if(isJumpButtonPressed)
        {
            Jump();
        }
        if(Mathf.Abs(direction) > 0.000f)
        {
            HorizontalMovement(direction);
        }
    }

    private void Jump()
    {
        if (isGrounded || RaycastGrondLeft || RaycastGrondRight)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (secondJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            secondJump = false;
        }
    }

    private void HorizontalMovement(float direction)
    {
        movementSpeed = isGrounded ? movementSpeedGround : movementSpeedAir;

        if (OverlapCircleGround && !RaycastGrondLeft && !RaycastGrondRight)
            movementSpeed = 0.2f; //практически полученная величина, при которой не происходит
        // "прилипания" к стене в воздухе, при этом можно соскочить с угла платформы

        rb.velocity = new Vector2(curve.Evaluate(direction) * movementSpeed, rb.velocity.y);

        animationStates.FlipSprite(direction);
    }

    private void CheckGround()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        Vector3 rayOrigin = groundColliderTransform.position;

        //пускаем два луча вниз с небольшим смещением угла в стороны
        RaycastGrondLeft = Physics2D.Raycast(rayOrigin, new Vector2(-0.25f, -1f), jumpOffset + 0.05f, ground);
        RaycastGrondRight = Physics2D.Raycast(rayOrigin, new Vector2(0.25f, -1f), jumpOffset + 0.05f, ground);

        OverlapCircleGround = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, ground);

        if ((RaycastGrondLeft || RaycastGrondRight) && OverlapCircleGround)
        {
            isGrounded = true;
            secondJump = true;
        }
        else isGrounded = false;
    }
}
