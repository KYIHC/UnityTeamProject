using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class BossPhaseTwo : Monster
{
    #region public 
    public float attackRange = 5.5f;
    public float skillRange = 15.0f;
    public Transform rayPosition;
    public int patterCount;
    #endregion
    #region private
    private BTSelector root;
    private BossAttack bossAttack; 
    private NavMeshAgent nav;
    private Animator anim;
    private bool isDie = false;
    #endregion

    private void Start()
    {
        root = new BTSelector();
        bossAttack = GetComponent<BossAttack>();
        BTSequence lifeCheckSequence = new BTSequence();
        BTSequence skillAttackSequence = new BTSequence();
        BTSequence attackSequence = new BTSequence();
        BTSequence chaseSequence = new BTSequence();
        BTAction skillAction = new BTAction(SkillAttack);
        BTAction attackAction = new BTAction(Attack);
        BTAction dieAction = new BTAction(Die);
        BTAction chaseAction = new BTAction(Chase);
        BTCondition playerRange = new BTCondition(IsPlayerInRange);
        BTCondition playerDie = new BTCondition(IsPlayerDie);
        BTCondition skillRange = new BTCondition(IsSkillRange);

        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        root.AddChild(lifeCheckSequence);
        root.AddChild(skillAttackSequence);
        root.AddChild(attackSequence);
        root.AddChild(chaseSequence);
        lifeCheckSequence.AddChild(playerDie);
        lifeCheckSequence.AddChild(dieAction);
        skillAttackSequence.AddChild(skillRange);
        skillAttackSequence.AddChild(skillAction);
        attackSequence.AddChild(playerRange);
        attackSequence.AddChild(attackAction);
        chaseSequence.AddChild(chaseAction);

        monsterName = MonsterDataManager.instance.bossPhaseTwo.name;
        maxHP = MonsterDataManager.instance.bossPhaseTwo.maxHP;
        currentHP = maxHP;

        root.Evaluate();
    }
    private void Update()
    {
        root.Evaluate();
    }

    private bool IsPlayerDie()
    {
        if (currentHP == 0) { return true; }
        else { return false; }
    }
    private bool IsSkillRange()
    {
        playerPosition = GameObject.FindWithTag("Player");
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.transform.position);
        if (distanceToPlayer <= skillRange && distanceToPlayer > 10)
        { return true; }
        else { return false; }
    }

    private bool IsPlayerInRange()
    {
        playerPosition = GameObject.FindWithTag("Player");
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.transform.position);
        return distanceToPlayer <= attackRange;
    }
    public BTState Die()
    {
        if (isDie == false)
        {
            nav.isStopped = true;
            anim.SetTrigger("isDeath");
            Destroy(gameObject, 4.0f);
            isDie = true;
            return BTState.Success;
        }
        else if (isDie == true)
        {
            return BTState.Success;
        }
        else { return BTState.Failure; }
    }

    public BTState SkillAttack()
    {
        if (bossAttack.isAttack == false && bossAttack.count[5] == true)
        {
            nav.isStopped = true;
            anim.SetBool("isChase", false);
            if (HeadCheck(skillRange))
            {
                bossAttack.StartJumpAndSpin();
            }
            else
            {
                Quaternion targetRotation = Quaternion.LookRotation(playerPosition.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
            }
            return BTState.Success;
        }
        else
        { 
            return BTState.Failure;
        }
    }
    public BTState Attack()
    {
        if (bossAttack.isAttack == false)
        {
            nav.isStopped = true;
            anim.SetBool("isChase", false);
            if (HeadCheck(attackRange))
            {
                bossAttack.AttackPatterm(patterCount);
            }
            else
            {
                Quaternion targetRotation = Quaternion.LookRotation(playerPosition.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
            }
            return BTState.Success;
        }
        else { return BTState.Failure; }
    }

    public BTState Chase()
    {
        if (bossAttack.isAttack == false)
        {
            Quaternion targetRotation = Quaternion.LookRotation(playerPosition.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
            nav.isStopped = false;
            anim.SetBool("isChase", true);
            nav.SetDestination(playerPosition.transform.position);
            return BTState.Success;
        }
        else { return BTState.Success; }
    }

    public override void Hit(float damage)
    {
        currentHP -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit");
        }
    }

    private bool HeadCheck(float attackRange)
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(rayPosition.position, rayPosition.forward, out hit, attackRange);
        if (isHit && hit.collider.CompareTag("Player"))
        {
            return true;
        }
        else { return false; }

    }
}
