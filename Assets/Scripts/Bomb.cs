using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float timeLiveBomb;
    [SerializeField] float bombForce;

    private PointEffector2D eff;

    private void Start()
    {
        eff = GetComponent<PointEffector2D>();
        eff.forceMagnitude = bombForce;
        Destroy(gameObject, timeLiveBomb);
    }
}
