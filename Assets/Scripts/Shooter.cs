using System.Collections;
using UnityEngine;


[RequireComponent(typeof(AnimationStates))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireForce;
    [SerializeField] private Transform leftBulletPoint;
    [SerializeField] private Transform rightBulletPoint;
    [SerializeField] private float lifeTimeBullet;

    private Transform bulletPoint;
    private AnimationStates animationStates;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animationStates = GetComponent<AnimationStates>();
    }

    public void Shoot(float direction)
    {
        if (animationStates.isLeft)
        {
            bulletPoint = leftBulletPoint;
        }
        else
        {
            bulletPoint = rightBulletPoint;
        }

        GameObject currentBullet = Instantiate(bullet, bulletPoint.position, Quaternion.identity);
        spriteRenderer = currentBullet.GetComponent<SpriteRenderer>();
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if (animationStates.isLeft)
        {
            ApplyCurrentBulletVelocity(-1, currentBulletVelocity);
            spriteRenderer.flipX = true;
        }
        else
        {
            ApplyCurrentBulletVelocity(1, currentBulletVelocity);
        }

        Coroutine coroutine = StartCoroutine(DestoyBullet(currentBullet, lifeTimeBullet));
    }

    private void ApplyCurrentBulletVelocity(int directionShoot, Rigidbody2D currentBulletVelocity)
    {
        currentBulletVelocity.velocity = new Vector2(fireForce * directionShoot, currentBulletVelocity.velocity.y);

    }

    IEnumerator DestoyBullet(GameObject currentBullet, float lifeTimeBullet)
    {
        yield return new WaitForSeconds(lifeTimeBullet);
        Destroy(currentBullet);
    }
}
