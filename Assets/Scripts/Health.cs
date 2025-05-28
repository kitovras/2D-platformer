using UnityEngine;

[RequireComponent(typeof(Death))]
public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    public bool isAlive => currentHealth > 0;

    private EventBus eventBus;
    private Death death;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        death = GetComponent<Death>();

        if (TryGetComponent(out PlayerInput player))
        {
            while (eventBus == null)
            {
                eventBus = FindObjectOfType<EventBus>();
            }
        }

        Invoke(nameof(StartDamage), 0.001f);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        eventBus?.ChangePlayerHealth.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            eventBus?.ChangePlayerHealth.Invoke(currentHealth);
            eventBus?.PlayerDeath.Invoke();
            death.Killing();
        }
    }

    public void TakeDamageToDie()
    {
        TakeDamage(maxHealth + 1);
    }

    public void TakeHealing(float healing)
    {
        currentHealth += healing;
        if (currentHealth > 100)
            currentHealth = 100;

        eventBus?.ChangePlayerHealth.Invoke(currentHealth);
    }

    private void StartDamage()
    {
        TakeDamage(0);
    }
}
