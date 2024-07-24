using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public float damage;
    private void Update()
    {
        damage = PlayerDataManager.instance.playerData.attackDamage;
    }
    
    

    
}
