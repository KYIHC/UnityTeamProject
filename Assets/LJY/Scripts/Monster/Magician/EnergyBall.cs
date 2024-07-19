using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonsterProjectile
{
    public GameObject impactParticle;
    public GameObject projectileParticle;
    public GameObject muzzleParticle;
    private void OnEnable()
    {
        lifeTime = 3f;
        speed = 10f;
        damage = 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Monster"))
        {
            return;
        }
        Destroy(gameObject);
    }
}
