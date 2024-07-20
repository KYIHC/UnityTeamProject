using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : MonsterProjectile
{

    private Rigidbody rb;
    public List<ParticleSystem> redball;

    void Start()
    {
        damage = MonsterDataManager.instance.bossDatas[4].damage;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        redball[0].Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(redball[0]);
            redball[1].transform.position = -transform.forward;
            redball[1].Play();
            Destroy(redball[1], 3);
            // other.gameObject.GetComponent<Character>().Hit(damage)
        }
        else if (other.gameObject.tag == "Boss")
        {
            return;
        }
        else if (other.gameObject.tag == "Ground")
        { 
        Destroy(redball[0]);
        redball[1].transform.position = -transform.forward;
        redball[1].Play();
        Destroy(redball[1], 3);
        }
    }
}
