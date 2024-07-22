using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardAttack : MonsterProjectile
{

    private void Start()
    {
        Invoke("ReturnStandardAttack", 3f);
    }

    public void ReturnStandardAttack()
    {
        MObjectPooling.Instance.ReturnObject(2, this);
    }

}
