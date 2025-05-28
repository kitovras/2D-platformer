using UnityEngine;
using UnityEngine.UI;

public class DisplayedHealth : MonoBehaviour
{
    [SerializeField] private Text healthBar;
    [SerializeField] private GameObject deathImage;
    public float displayedHealth;

    private EventBus eventBus;

    private void Start()
    {
        while (eventBus == null)
        {
            eventBus = FindObjectOfType<EventBus>();
        }
        eventBus?.ChangePlayerHealth.AddListener(RedrawHealthbar);
    }

    private void RedrawHealthbar(float currentHealth)
    {
        displayedHealth = Mathf.Round(currentHealth);

        healthBar.text = displayedHealth.ToString();
    }

    public void DrawDeathBar()
    {
        deathImage.SetActive(true);
    }

    private void OnDestroy()
    {
        eventBus?.ChangePlayerHealth.RemoveListener(RedrawHealthbar);
    }
}
