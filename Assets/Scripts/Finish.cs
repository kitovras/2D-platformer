using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject finishMenu;
    [SerializeField] Text finishCoinScope;
    private CoinScope coinScope;

    private EventBus eventBus;

    private void Start()
    {
        while (eventBus == null)
        {
            eventBus = FindObjectOfType<EventBus>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerInput>(out var playerInput))
        {
            finishMenu.SetActive(true);
            eventBus.BlockPlayerMovement.Invoke();
        }
    }
}
