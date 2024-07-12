using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mage : Monster
{
    #region private 변수
    private GameManager gameManager;
    private Vector3 playerPosition;
    #endregion

    #region 몬스터 정보 변수

    #endregion

    #region 상태관련 private변수 및 열거형
    private enum State
    {
        Idle,
        Move,
        Attack,
        Die
    }
    private State currentState;
    private StateMachine stateMachine;
    #endregion

    public override void Hit(float damage)
    {
        base.Hit(damage);
    }

    private void Start()
    {
        gameManager = GameManager.instance;
        gameManager.character.transform.position = playerPosition;
        maxHP = 100;
        currentHP = maxHP;
        currentState = State.Idle;
        stateMachine = new StateMachine(new MIdleState(this));
    }


    private void Update()
    {
        if (currentHP != 0)
        {
            switch (currentState)
            {
                case State.Idle:
                    if (CanSeePlayer())
                    {
                        if (OnAttackArea())
                        {
                            ChangeState(State.Attack);
                        }
                        else
                        {
                            ChangeState(State.Move);
                        }
                    }
                    break;
                case State.Move:
                    if (CanSeePlayer() && OnAttackArea())
                    {
                        ChangeState(State.Attack);
                    }
                    else
                    {
                        ChangeState(State.Idle);
                    }
                    break;
                case State.Attack:
                    if (CanSeePlayer() && !OnAttackArea())
                    {
                        ChangeState(State.Move);
                    }
                    else
                    {
                        ChangeState(State.Idle);
                    }
                    break;
            }
        }
        else
        {
            ChangeState(State.Die);
        }
    }

    private void ChangeState(State nextState)
    {
        currentState = nextState;
        switch (currentState)
        {
            case State.Idle:
                stateMachine.ChangeState(new MIdleState(this));
                break;
            case State.Move:
                stateMachine.ChangeState(new MMoveState(this));
                break;
            case State.Attack:
                stateMachine.ChangeState(new MAttackState(this));
                break;
            case State.Die:
                stateMachine.ChangeState(new MDieState(this));
                break;
        }
    }

    private bool CanSeePlayer()
    {

        float distance = Vector3.Distance(playerPosition, transform.position);
        if (distance < 20f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool OnAttackArea()
    {
        float distance = Vector3.Distance(playerPosition, transform.position);
        if (distance < 10f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
