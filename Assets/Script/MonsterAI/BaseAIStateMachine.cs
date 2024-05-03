using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAIStateMachine : MonoBehaviour
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
}
