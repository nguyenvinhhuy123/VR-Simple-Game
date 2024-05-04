using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedState : BaseAIState
{
    public DamagedState(MonsterAIStateMachine stateMachine): base(stateMachine)
    {
        
    }
    public override void OnEnter()
    {
        base.OnEnter();
        _stateMachine.m_animation.PlayDamaged();
        var moveDirection = m_self.transform.position - m_target.transform.position;
        _stateMachine.m_body.AddForce(moveDirection.normalized * -500f);
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (!_stateMachine.m_animation.IsPlaying())
        {
            _stateMachine.OnChangeState(_stateMachine.ChasingState);
        }
    }
}
