using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;

    private bool itWorks = true;
    private float layersCount;
    private void Start()
    {
        layersCount = layers.Length;
    }

    void Update()
    {
        UseParallax();
    }

    private void UseParallax()
    {
        if (itWorks)
        {
            for (int i = 0; i < layersCount; i++)
            {
                layers[i].position = transform.position * coeff[i];
            }
        }
    }

    public void OffParallax()
    {
        itWorks = false;
    }
}
