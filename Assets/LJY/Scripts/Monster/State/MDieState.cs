using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MDieState : MBaseState
{
    public MDieState(Monster monster) : base(monster) { }

    private Animator anim;
    private NavMeshAgent nav;

    public override void OnStateEnter()
    {
        nav = monster.GetComponent<NavMeshAgent>();
        anim = monster.GetComponent<Animator>();
        nav.enabled = false;
        anim.SetTrigger("isDie");
        monster.Invoke("Destroy", 3f);
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {

    }
}

