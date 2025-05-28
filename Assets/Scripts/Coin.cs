using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject coinParticleSystem;
    [SerializeField] private float coinValue = 1;

    private Renderer coinRenderer;
    private ParticleSystem particleSystem;
    private Collider2D collider2D;

    private EventBus eventBus;

    private void Start()
    {
        coinRenderer = GetComponent<Renderer>();
        collider2D = gameObject.GetComponent<Collider2D>();
        particleSystem = coinParticleSystem.GetComponent<ParticleSystem>();

        while (eventBus == null)
        {
            eventBus = FindObjectOfType<EventBus>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerInput>(out _))
        {
            coinParticleSystem?.SetActive(true);
            coinRenderer.enabled = false;
            collider2D.enabled = false;
            eventBus?.AddCoin.Invoke(coinValue);
            Destroy(gameObject, particleSystem.duration);
        }
    }
}
