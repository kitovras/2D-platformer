using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] GameObject DeathMenu;

    private EventBus eventBus;

    private void Start()
    {
        while (eventBus == null)
        {
            eventBus = FindObjectOfType<EventBus>();
        }
        eventBus?.PlayerDeath.AddListener(ShowDeathMenu);
    }

    private void ShowDeathMenu()
    {
        DeathMenu.SetActive(true);
    }
}
