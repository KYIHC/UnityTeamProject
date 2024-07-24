using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickAttackDamage : PlayerWeapon
{
    

    
    void Update()
    {
        damage = PlayerDataManager.instance.playerData.attackDamage;
    }
}
