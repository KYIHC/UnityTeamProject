using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonsterProjectile
{

    private void Update()
    {
        damage = MonsterDataManager.instance.bossAttackDamage;
    }

}
