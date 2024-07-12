using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MMoveState : MBaseState
{
    public MMoveState(Monster monster): base(monster) { }

    private Animator anim;
    private NavMeshAgent nav;
    public override void OnStateEnter()
    {
        anim = monster.GetComponent<Animator>();
        nav = monster.GetComponent<NavMeshAgent>();
        anim.SetBool("isRun", true);
    }

    public override void OnStateUpdate()
    {
        monster.transform.LookAt(monster.playerPosition.transform.position);
        nav.SetDestination(monster.playerPosition.transform.position);
        Debug.Log("Move");
        
    }

    public override void OnStateExit()
    {
        anim.SetBool("isRun", false);
    }
}

