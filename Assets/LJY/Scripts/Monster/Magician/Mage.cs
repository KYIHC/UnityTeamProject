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
        base.Hit(damage);
    }

    private void Start()
    {
        monsterName = MonsterDataManager.instance.magicData.name;
        maxHP = MonsterDataManager.instance.magicData.maxHP;
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
                MUIManager.instance.MonsterUI.SetActive(false);
                DungeonManager.instance.currentWave--;
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
        if (distance < 10f)
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
        var energyBall =  MObjectPooling.GetObject(1);
        energyBall.transform.position = ShootPoint.position;
        energyBall.transform.rotation = ShootPoint.rotation;
        energyBall.transform.forward = ShootPoint.forward;
        energyBall.Shoot();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Hit(other.GetComponent<Character>().damage);
            MUIManager.instance.MonsterUI.SetActive(false);
            MUIManager.instance.hpbar.fillAmount = currentHP / maxHP;
            MUIManager.instance.hpText.text = $"{currentHP + " / " + maxHP}";
            MUIManager.instance.monsterName.text = monsterName;
            MUIManager.instance.monsterImage.sprite = MUIManager.instance.MonsterSprite[0];
            MUIManager.instance.MonsterUI.SetActive(true);
        }
    }
}
