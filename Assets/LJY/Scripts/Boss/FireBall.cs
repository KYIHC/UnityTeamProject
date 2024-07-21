using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonsterProjectile
{
    private Rigidbody rb;
    public ParticleSystem[] fireBall;

    private void Awake()
    {
        damage = MonsterDataManager.instance.bossPhaseTwo.skills[3].damage;
        rb = GetComponent<Rigidbody>();
        fireBall[0].Play();
        Invoke("ReturnFireBall", 5f);
    }

    private void Start()
    {
        Invoke("ReturnFireBall", 5f);
    }
    public void ReturnFireBall()
    {
        this.rb.velocity = Vector3.zero;
        MObjectPooling.Instance.ReturnObject(0,this);
    }
    public override void Shoot()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fireBall[0].Stop();
            fireBall[1].Play();
            // other.gameObject.GetComponent<Character>().Hit(damage)
        }
        else if (other.gameObject.tag == "Boss")
        {
            return;
        }
        else if (other.gameObject.tag == "Ground")
        {
            fireBall[0].Stop();
            fireBall[1].Play();
        }
        Invoke("ReturnFireBall", 1.5f);
    }
}
