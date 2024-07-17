using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MAttackState : MBaseState
{
    public MAttackState(Monster monster): base(monster) { }
    private Animator anim;
    private NavMeshAgent nav;
    public override void OnStateEnter()
    {
        anim = monster.GetComponent<Animator>();
        nav = monster.GetComponent<NavMeshAgent>();
        monster.attackObject.SetActive(true);
        anim.SetBool("isAttack", true);
        nav.isStopped = true;
    }

    public override void OnStateUpdate()
    {
        monster.transform.LookAt(monster.playerPosition.transform.position);
    }

    public override void OnStateExit()
    {
        monster.attackObject.SetActive(false);
        nav.isStopped = false;
        anim.SetBool("isAttack", false);
    }
}
