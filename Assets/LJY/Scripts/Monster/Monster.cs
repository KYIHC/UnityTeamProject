using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour,IHitable
{
    #region public 변수 
    public GameObject playerPosition;
    #endregion

    #region 몬스터 정보 변수
    public string monsterName;
    public float maxHP;
    public float currentHP;
    public float damage;
    #endregion

    public virtual void Hit(float damage)
    {
        currentHP -= damage;    
    }
}
