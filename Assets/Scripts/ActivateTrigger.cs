using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    [SerializeField] GameObject activateGameObject;
    [SerializeField] private bool activateIt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activateGameObject != null)
        {
            activateGameObject.SetActive(activateIt);
        }
    }
}
