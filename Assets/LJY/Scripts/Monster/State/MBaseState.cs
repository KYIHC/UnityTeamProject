using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MBaseState
{
    protected Monster monster;

    protected MBaseState(Monster monster)
    {
        this.monster = monster;
    }

    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();

}
