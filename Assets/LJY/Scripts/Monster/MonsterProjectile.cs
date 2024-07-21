using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterProjectile : MonoBehaviour
{
    public float speed = 10;
    public float damage;

    public virtual void Shoot() { }
    
}
