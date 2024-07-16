using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mage : Monster
{
    #region private 변수
    private bool isDie = false;
    #endregion

    #region public 변수
    public MonsterProjectile projectilePrefab;
    public Transform ShootPoint;
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
        currentHP -= damage;  
    }

    private void Start()
    {

        currentHP = maxHP;
        currentState = State.Idle;
        stateMachine = new StateMachine(new MIdleState(this));
    }


    private void Update()
    {
        if (currentHP > 0)
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
                    if (CanSeePlayer())
                    {
                        if (OnAttackArea())
                        {
                            ChangeState(State.Attack);
                        }
                    }
                    else
                    {
                        ChangeState(State.Idle);
                    }
                    break;
                case State.Attack:
                    if (CanSeePlayer())
                    {
                        if (OnAttackArea() == false)
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
            if (isDie == false)
            {
                isDie = true;
                ChangeState(State.Die);

            }
        }

        stateMachine.UpdateState();
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
                stateMachine.ChangeState(new MRangeAttack(this));
                break;
            case State.Die:
                stateMachine.ChangeState(new MDieState(this));
                break;
        }
    }

    private bool CanSeePlayer()
    {
        playerPosition = GameObject.FindWithTag("Player");
        float distance = Vector3.Distance(playerPosition.transform.position, transform.position);
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
        playerPosition = GameObject.FindWithTag("Player");
        float distance = Vector3.Distance(playerPosition.transform.position, transform.position);
        if (distance < 7f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Shoot()
    {
        MonsterProjectile energyBall = Instantiate(projectilePrefab, ShootPoint.position, ShootPoint.rotation);
        
        energyBall.GetComponent<Rigidbody>().AddForce(ShootPoint.forward * energyBall.speed,ForceMode.Impulse);
        Destroy(energyBall, 3f);

    }
}
