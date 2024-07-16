using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MAttackState : MBaseState
{
    public MAttackState(Monster monster): base(monster) { }
    private Animator anim;
    private NavMeshAgent nav;
    private Collider attackCollider;
    public override void OnStateEnter()
    {
        anim = monster.GetComponent<Animator>();
        nav = monster.GetComponent<NavMeshAgent>();
        attackCollider = monster.attackCollider;
        anim.SetBool("isAttack", true);
        nav.isStopped = true;
    }

    public override void OnStateUpdate()
    {
        monster.transform.LookAt(monster.playerPosition.transform.position);
    }

    public override void OnStateExit()
    {
        attackCollider.enabled = false;
        nav.isStopped = false;
        anim.SetBool("isAttack", false);
    }
}
