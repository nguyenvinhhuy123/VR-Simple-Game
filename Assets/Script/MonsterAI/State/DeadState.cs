using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseAIState
{
    public DeadState(MonsterAIStateMachine stateMachine): base(stateMachine)
    {
        
    }
    public override void OnEnter()
    {
        base.OnEnter();
        _stateMachine.m_animation.PlayDead();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (!_stateMachine.m_animation.IsPlaying())
        {
            GameObject.Destroy(_stateMachine.m_controllerInstance.gameObject);
        }
    }
}
