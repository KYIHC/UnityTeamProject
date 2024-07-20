using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonsterProjectile
{

    private Rigidbody rb;
    public List<ParticleSystem> redball;

    private void Awake()
    {
        damage = MonsterDataManager.instance.bossTwoDatas[3].damage;
        rb = GetComponent<Rigidbody>();
        redball[0].Play();
    }

    public void ReturnFireBall()
    {
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
            redball[0].Stop();
            redball[1].Play();
            // other.gameObject.GetComponent<Character>().Hit(damage)
        }
        else if (other.gameObject.tag == "Boss")
        {
            return;
        }
        else if (other.gameObject.tag == "Ground")
        {
            redball[0].Stop();
            redball[1].Play();
        }
        Invoke("ReturnFireBall", 1.5f);
    }
}
