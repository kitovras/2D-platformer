using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VisualizationDamage : MonoBehaviour
{
    [SerializeField] private GameObject particleSystem;

    private SpriteRenderer spriteRenderer;
    private Color startColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
    }

    public void VisualityDamage()
    {
        if (particleSystem != null)
        {
            Instantiate(particleSystem, transform);
        }

        spriteRenderer.color = new Color(1, 0, 0, 1);
        StartCoroutine(ResetColor(spriteRenderer));
    }

    IEnumerator ResetColor(SpriteRenderer spriteRenderer)
    {
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = startColor;
    }
}
