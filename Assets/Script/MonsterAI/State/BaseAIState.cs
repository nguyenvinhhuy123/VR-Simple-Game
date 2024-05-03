using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAIState : IAIState
{
    protected MonsterAIStateMachine _stateMachine;
    protected Transform _playerTransform;
    public BaseAIState(MonsterAIStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public virtual void OnEnter()
    {

    }
    public virtual void OnExit()
    {
        
    }
    public virtual void OnUpdate()
    {
        
    }
    public virtual void OnFixedUpdate()
    {
        
    }
}
