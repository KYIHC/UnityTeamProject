using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour,IHittable
{
    #region public 변수 
    [HideInInspector]
    public GameObject playerPosition;
    public AudioClip[] monsterAudio;
    #endregion

    #region 몬스터 정보 변수
    public string monsterName;
    public float maxHP;
    public float currentHP;
    public float damage;
 

    public GameObject attackObject;
    #endregion

    public virtual void Hit(float damage)
    {
        currentHP -= damage;    
    }
}
