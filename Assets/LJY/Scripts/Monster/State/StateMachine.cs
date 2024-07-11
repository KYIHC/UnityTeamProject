using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    #region priavate º¯¼ö
    private MBaseState currentState;
    #endregion

    public StateMachine(MBaseState initState)
    {
        currentState = initState;
        ChangeState(currentState);
    }


    public void ChangeState(MBaseState changeState)
    {
        if (changeState == currentState)
        {
            return;
        }

        if (currentState != null)
        {
            currentState.OnStateExit();

            currentState = changeState;
            currentState.OnStateEnter();
        }
    }

    public void UpdateState()
    {
        if (currentState != null)
        {
            currentState.OnStateUpdate();
        }
    }
}
