using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : BaseAIState
{
    
    private float m_attackTimer;
    public AttackState(MonsterAIStateMachine stateMachine): base(stateMachine)
    {
        
    }
    public override void OnEnter()
    {
        base.OnEnter();
        m_attackTimer = 0f;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (_stateMachine.m_controllerInstance.DistanceToPlayer 
        > _stateMachine.m_controllerInstance.AttackRange 
        && m_attackTimer < 0f)
        {
            _stateMachine.OnChangeState(_stateMachine.ChasingState);
        }
        Attack();
    }
    public override void OnFixedUpdate()
    {
        m_attackTimer -= Time.fixedDeltaTime;
    }
        public override void OnExit()
    {
        base.OnExit();
        _stateMachine.m_controllerInstance.HitBox.SetActive(false);
    }
    private void Attack()
    {
        if (m_attackTimer > 0f && !_stateMachine.m_animation.IsPlaying())
        {
            _stateMachine.m_controllerInstance.HitBox.SetActive(false);
        }
        if (m_attackTimer <= 0f)
        {
            m_attackTimer = 1 / _stateMachine.m_controllerInstance.AttackRate;
            _stateMachine.m_controllerInstance.HitBox.SetActive(true);
            _stateMachine.m_animation.PlayAttack();
        }
    }

}
