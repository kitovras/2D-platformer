using UnityEngine;
using UnityEngine.Events;

public class EventBus : MonoBehaviour
{
    //Доступные события
    public UnityEvent<float> AddCoin;

    public UnityEvent<float> ChangePlayerHealth;
    public UnityEvent PlayerDeath;
    public UnityEvent BlockPlayerMovement;
    public UnityEvent UnblockPlayerMovement;
    public UnityEvent EscapePressed;

    public UnityEvent SceneReload;

    private void Awake()
    {
        if(FindObjectsOfType<EventBus>().Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
