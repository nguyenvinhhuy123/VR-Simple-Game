using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAIState : IAIState
{
    protected MonsterAIStateMachine _stateMachine;
    protected Transform m_target;
    protected Transform m_self;
    private int m_damping = 2;
    public BaseAIState(MonsterAIStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        m_target = stateMachine.m_controllerInstance.m_playerTransform;
        m_self = _stateMachine.m_controllerInstance.m_selfTransform;
    }
    public virtual void OnEnter()
    {
        Debug.Log(this.GetType().Name);
    }
    public virtual void OnExit()
    {

    }
    public virtual void OnUpdate()
    {
        var lookPos = m_target.position - m_self.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        m_self.rotation = Quaternion.Slerp(m_self.rotation, rotation, Time.deltaTime * m_damping);
    }
    public virtual void OnFixedUpdate()
    {

    }
}
