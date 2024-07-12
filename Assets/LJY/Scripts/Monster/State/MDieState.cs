using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDieState : MBaseState
{
    public MDieState(Monster monster) : base(monster) { }

    private Animator anim;

    public override void OnStateEnter()
    {
        anim = monster.GetComponent<Animator>();
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

