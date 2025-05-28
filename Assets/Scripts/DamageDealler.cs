using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool IsBullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("CameraBorders") && !collision.CompareTag("EnemyStopper"))
        {
            if (collision.TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(damage);
            }

            if (!collision.TryGetComponent<Coin>(out _) && !collision.TryGetComponent<HealthPotion>(out _) && IsBullet)
            {
                Destroy(gameObject);
            }
        }
    }
}
