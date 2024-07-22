using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpin : MonsterProjectile
{
    private SphereCollider sphereCollider;
    private void Start()
    {
        damage = MonsterDataManager.instance.bossPhaseTwo.skills[2].damage;
        //sphereCollider = GetComponent<SphereCollider>();

    }

    public void Stop()
    {
        sphereCollider.enabled = false;
    }
}
    
