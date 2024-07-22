using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : BossAttack
{


    private float myDamage;
    private void Update()
    {
        myDamage = base.damage;
    }

}
