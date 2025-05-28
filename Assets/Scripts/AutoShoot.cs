using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Shooter))]
public class AutoShoot : MonoBehaviour
{
    [SerializeField] private float direction;
    [SerializeField] private float reloadTime;
    private Shooter shooter;

    private void Start()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Awake()
    {
        StartCoroutine(AutoShooting(true));
    }

    IEnumerator AutoShooting(bool isActive)
    {
        while (isActive)
        {
            yield return new WaitForSeconds(reloadTime);
            shooter.Shoot(direction);
        }
    }
}
