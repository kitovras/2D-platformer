using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject particleSystemDeath;
    [SerializeField] Transform transformDeathParticleSystem;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject bomb;

    public void Killing()
    {
        if (particleSystemDeath != null && transformDeathParticleSystem != null)
        {
            Instantiate(particleSystemDeath, transformDeathParticleSystem.position, transformDeathParticleSystem.rotation);
            if (coin != null)
            {
                Instantiate(coin, transformDeathParticleSystem.position, transformDeathParticleSystem.rotation);
            }
            if (bomb != null) {
                Instantiate(bomb, transform.position, transform.rotation);
            }
        }
        Destroy(gameObject);
    }
}
 