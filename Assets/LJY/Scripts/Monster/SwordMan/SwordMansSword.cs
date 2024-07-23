using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMansSword : MonsterProjectile
{
    private void Start()
    {
        damage = MonsterDataManager.instance.swordManData.damage;
       
    }
}
