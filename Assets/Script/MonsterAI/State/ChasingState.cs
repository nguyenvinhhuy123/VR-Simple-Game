using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChasingState : BaseAIState
{
    private Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
    {
        int num = (int)(target.x - current.x);
        int num2 = (int)(target.y - current.y);
        int num3 = (int)(target.z - current.z);
        float num4 = num * num + num2 * num2 + num3 * num3;
        if (num4 == 0f || (maxDistanceDelta >= 0f && num4 <= maxDistanceDelta * maxDistanceDelta))
        {
            return target;
        }
        float num5 = Mathf.Sqrt(num4);

        return new Vector3(current.x + num / num5 * maxDistanceDelta, current.y + num2 / num5 * maxDistanceDelta, current.z + num3 / num5 * maxDistanceDelta);
    }
    private float m_step;
    public ChasingState(MonsterAIStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void OnEnter()
    {
        base.OnEnter();
        _stateMachine.m_animation.PlayRun();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (_stateMachine.m_controllerInstance.DistanceToPlayer
        > _stateMachine.m_controllerInstance.AttackRange)
        {
            m_step = _stateMachine.m_controllerInstance.RunSpeed * Time.deltaTime;
            m_self.position = MoveTowards(
            m_self.position,
            m_target.position, m_step);
        }


    }
    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        if (_stateMachine.m_controllerInstance.DistanceToPlayer
        <= _stateMachine.m_controllerInstance.AttackRange)
        {
            _stateMachine.OnChangeState(_stateMachine.AttackState);
        }
    }

}
