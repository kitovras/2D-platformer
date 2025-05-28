using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BarrelBomb : MonoBehaviour
{
    [SerializeField] float bumValue;
    [SerializeField] GameObject bomb;

    private Collider2D collider2D;
    private Death death;

    private void Start()
    {
        collider2D = GetComponent<Collider2D>();
        death = GetComponent<Death>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > bumValue)
        {
            Instantiate(bomb, transform.position, transform.rotation);
            death.Killing();
        }
    }
}
