using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class AnimationStates : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public bool isLeft = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void QuickAttackState()
    {
        animator.SetTrigger("isQuickAttacking");
    }

    public void FlipSprite(float direction)
    {
        if (direction < 0)
        {
            spriteRenderer.flipX = true;
            isLeft = true;
        }
        else
        {
            spriteRenderer.flipX = false;
            isLeft = false;
        }
    }

    public void DeathState()
    {
        animator.SetBool("isDeath", true);
    }
}
