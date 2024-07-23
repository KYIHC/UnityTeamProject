using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonsterProjectile
{
    private Rigidbody rb;
    public ParticleSystem[] energyBall;

    private void OnEnable()
    {
        damage = MonsterDataManager.instance.magicData.damage;
        rb = GetComponent<Rigidbody>();
        energyBall[0].Play();
        Invoke("ReturnEnergyBall", 5f);
    }

    public void ReturnEnergyBall()
    {
        this.rb.velocity = Vector3.zero;
        MObjectPooling.Instance.ReturnObject(1, this);
    }
    public override void Shoot()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag("Player"))
        {
            energyBall[0].Stop();
            Invoke("ReturnEnergyBall", 1.5f);
        }
        else
        if (other.CompareTag("Monster"))
        {
            return;
        }
        ReturnEnergyBall();
    }
}
