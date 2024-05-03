using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAIStateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    protected IAIState currentState;
    
    public void OnChangeState(IAIState nextState)
    {
        if (currentState == nextState) return;
        //A state should change to itself
        currentState?.OnExit();
        currentState = nextState;
        currentState?.OnEnter();
    }
    public void OnInputHandle()
    {
        currentState?.OnInputHandle();
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
