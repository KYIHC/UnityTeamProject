using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour,IHittable
{
    #region public ���� 
    [HideInInspector]
    public GameObject playerPosition;
    public AudioClip[] monsterAudio;
    #endregion

    #region ���� ���� ����
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
