using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseAIState
{
    private float m_delayTime = 0.25f;
    private float m_delayTimer = 0.25f;
    public DeadState(MonsterAIStateMachine stateMachine) : base(stateMachine)
    {

    }
    public override void OnEnter()
    {
        base.OnEnter();
        m_delayTimer = m_delayTime;
        _stateMachine.m_animation.PlayDead();
    }
    public override void OnFixedUpdate()
    {
        m_delayTimer -= Time.fixedDeltaTime;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (m_delayTimer < 0f && !_stateMachine.m_animation.IsPlaying())
        {
            GameObject.Destroy(_stateMachine.m_controllerInstance.gameObject);
        }
    }
}
