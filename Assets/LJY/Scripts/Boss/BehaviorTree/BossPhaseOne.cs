using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class BossPhaseOne : Monster
{

    public float attackRange = 7.0f;
    public float moveSpeed = 4.0f;

    private BTSelector root;
    private BossAttack bossAttack;
    private Animator anim;
    private NavMeshAgent nav;

    private void OnEnable()
    {
        root = new BTSelector();
        BTSequence attackSequence = new BTSequence();
        BTSequence chaseSequence = new BTSequence();
        BTActtion attackActtion = new BTActtion(Attack);
        BTActtion chaseActtion = new BTActtion(Chase);
        BTCondition playerRange = new BTCondition(IsPlayerInRange);
        bossAttack = GetComponent<BossAttack>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>(); 

        root.AddChild(attackSequence);
        root.AddChild(chaseSequence);
        attackSequence.AddChild(playerRange);
        attackSequence.AddChild(attackActtion);
        chaseSequence.AddChild(chaseActtion);

        root.Evaluate();
    }

    private void Update()
    {
        if (!bossAttack.isAttack)
        {
            root.Evaluate();
        }
    }


    private bool IsPlayerInRange()
    {
        playerPosition = GameObject.FindWithTag("Player");
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.transform.position);
        return distanceToPlayer <= attackRange;
    }

    public BTState Attack()
    {
        if (bossAttack.isAttack == false)
        {
            nav.isStopped = true;
            StartCoroutine(bossAttack.BasicAttack());
            return BTState.Success;
        }
        else
        {
            return BTState.Running;
        }
    }

    public BTState Chase()
    {
        if (bossAttack.isAttack == false && !IsPlayerInRange())
        {
            Quaternion targetRotation = Quaternion.LookRotation(playerPosition.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f);
            nav.isStopped = false;
            anim.SetBool("isChase", true);
            nav.SetDestination(playerPosition.transform.position);
            return BTState.Running;
        }
        else
        {
            anim.SetBool("isChase", false);
            return BTState.Success;
        }
    }

    public override void Hit(float damage)
    {
        currentHP -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<IHitable>().Hit(damage);
        }

    }
}
