using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MRangeAttack : MBaseState
{
    public MRangeAttack(Monster monster) : base(monster) { }

    private Animator anim;
    private NavMeshAgent nav;

    public override void OnStateEnter()
    {
        anim = monster.GetComponent<Animator>();
        nav = monster.GetComponent<NavMeshAgent>();
        nav.isStopped = true;
        anim.SetBool("isAttack", true);
    }

    public override void OnStateUpdate()
    {   
        monster.transform.LookAt(monster.playerPosition.transform.position);    
    }

    public override void OnStateExit()
    {
        nav.isStopped = false;
        anim.SetBool("isAttack", false);
    }


}
