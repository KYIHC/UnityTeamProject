using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : BossAttack
{

    private float myDamage;
    private void Update()
    {
        Debug.Log(base.damage);
        myDamage = base.damage;
        damage = myDamage;
    }

}
