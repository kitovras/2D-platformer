using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private EventBus eventBus;
    private void Start()
    {
        while (eventBus == null)
        {
            eventBus = FindObjectOfType<EventBus>();
        }
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        eventBus.SceneReload.Invoke();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        eventBus.SceneReload.Invoke();
    }
}
