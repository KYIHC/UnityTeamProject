using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour,IHitable
{
    #region ���� ���� ����
    public string monsterName;
    public float maxHP;
    public float currentHP;
    public float damage;
    #endregion

    #region ���� ���� 
    private enum State
    {
        Idle,
        Move,
        Attack,
        Die
    }
    private State currentState;
    #endregion

    private void Start()
    {
        currentState = State.Idle;
    }

    public virtual void Hit(float damage)
    {
        currentHP -= damage;    
    }
}
