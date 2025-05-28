using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private EventBus eventBus;

    private void Start()
    {
        while (eventBus == null) { 
            eventBus = FindObjectOfType<EventBus>();
        }
        eventBus?.EscapePressed.AddListener(InteractWithPauseMenu);
        eventBus?.SceneReload.AddListener(PlayTime);
    }
    private void InteractWithPauseMenu()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            PlayTime();
            eventBus?.UnblockPlayerMovement.Invoke();
        }
        else
        {
            pauseMenu.SetActive(true);
            PauseTime();
            eventBus?.BlockPlayerMovement.Invoke();
        }
    }

    private void PauseTime()
    {
        Time.timeScale = 0.0f;
    }

    private void PlayTime()
    {
        Time.timeScale = 1.0f;
    }

    public void ChangeTime(float time)
    {
        Time.timeScale = time;
    }
}
