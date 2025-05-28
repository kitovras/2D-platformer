using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangingTransparency : MonoBehaviour
{
    private Image image;
    private Color startColor;
    private float alpha = 1f;
    private EventBus eventBus;
    private void Start()
    {
        image = GetComponent<Image>();
        MakeItTransparent();
        while (eventBus == null)
        {
            eventBus = FindObjectOfType<EventBus>();
        }
        eventBus.SceneReload.AddListener(MakeItTransparent);
    }

    private void MakeItTransparent()
    {
        StartCoroutine(ReduceAlpha(image));
    }

    IEnumerator ReduceAlpha(Image image)
    {
        yield return new WaitForSeconds(0.05f);
        if (alpha > 0)
            alpha -= 0.1f;
        if (alpha <= 0)
            Destroy(gameObject);

        image.color = new Color(0, 0, 0, alpha);

        if (alpha > 0)
            StartCoroutine(ReduceAlpha(image));
    }
}
