using UnityEngine;

[RequireComponent (typeof(Renderer))]
[RequireComponent(typeof(Collider2D))]
public class HealthPotion : MonoBehaviour
{
    [SerializeField] private GameObject healthParticleSystem;
    [SerializeField] private float healingValue = 50;

    private Renderer healthPotionRender;
    private Collider2D healthPotionCollider;
    private ParticleSystem particleSystem;

    void Start()
    {
        healthPotionRender = GetComponent<Renderer>();
        healthPotionCollider = GetComponent<Collider2D>();
        particleSystem = healthParticleSystem.GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerInput>(out _))
        {
            if(collision.TryGetComponent<Health>(out Health health))
            {
                health.TakeHealing(healingValue);
                healthParticleSystem?.SetActive(true);
                healthPotionRender.enabled = false;
                healthPotionCollider.enabled = false;
                Destroy(gameObject, particleSystem.duration);
            }
        }
    }
}
