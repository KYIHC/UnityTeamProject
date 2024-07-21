using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest2 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MonsterSword")
        {
            float damage = other.GetComponent<BossAttack>().damage;
            Debug.Log(damage);
        }
    }
}
