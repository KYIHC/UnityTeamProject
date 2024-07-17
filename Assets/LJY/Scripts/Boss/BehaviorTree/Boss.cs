using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Boss : Monster
{
    #region public
    public float attackRange = 5.5f;
    public Transform rayPosition;
    public int patterCount;
    #endregion
    #region private
    private BTSelector root;
    private BossAttack bossAttack;
    private NavMeshAgent nav;
    private Animator anim;
    #endregion
 
    private void OnEnable()
    {
        root = new BTSelector();
        bossAttack = GetComponent<BossAttack>();
        BTSequence attackSequence = new BTSequence();
        BTSequence chaseSequence = new BTSequence();
        BTAction attackActtion = new BTAction(Attack);
        BTAction chaseActtion = new BTAction(Chase);
        BTCondition playerRange = new BTCondition(IsPlayerInRange);
        
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
        root.Evaluate();
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
            anim.SetBool("isChase", false);
            if (HeadCheck())
            {
                bossAttack.PhaseOneAttack(patterCount);
            }
            else
            {
                Quaternion targetRotation = Quaternion.LookRotation(playerPosition.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
            }
            return BTState.Success;
        }
        else if (bossAttack.isAttack == true)
        {
            return BTState.Running;
        }
        else { return BTState.Failure; }
    }

    public BTState Chase()
    {
        if (bossAttack.isAttack == false && !IsPlayerInRange())
        {
            Quaternion targetRotation = Quaternion.LookRotation(playerPosition.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
            nav.isStopped = false;
            anim.SetBool("isChase", true);
            nav.SetDestination(playerPosition.transform.position);
            return BTState.Running;
        }
        else if (bossAttack.isAttack == true)
        {
            return BTState.Success;
        }
        else { return BTState.Failure; }
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

    private bool HeadCheck()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(rayPosition.position, rayPosition.forward, out hit, attackRange);
        if (isHit && hit.collider.CompareTag("Player"))
        {
            Debug.Log("HeadCheck");
            return true;
        }
        else { return false; }

    }

}