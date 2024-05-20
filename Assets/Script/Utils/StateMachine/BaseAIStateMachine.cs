using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAIStateMachine
{
    protected IAIState currentState;

    public void OnChangeState(IAIState nextState)
    {
        if (currentState == nextState) return;
        //A state shouldn't change to itself
        currentState?.OnExit();
        currentState = nextState;
        currentState?.OnEnter();
    }
    public void OnUpdate()
    {
        currentState?.OnUpdate();
    }
    public void OnFixedUpdate()
    {
        currentState?.OnFixedUpdate();
    }
    public void PrintCurrentState()
    {
        Debug.Log("Current state: " + currentState);
    }
}
