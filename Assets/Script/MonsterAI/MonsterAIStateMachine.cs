using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAIStateMachine : BaseAIStateMachine
{
    public Rigidbody m_body {get;}
    public AnimationAdapter m_animation {get;}
    public Health m_health {get;}
    public Damage m_damage {get;}
    public GameObject m_hitBox {get;}
    //Controller
    public MonsterAIController m_controllerInstance {get;}
    //State initialization
    public DamagedState DamagedState {get; private set;}
    public ChasingState ChasingState {get; private set;}
    public AttackState AttackState {get; private set;}
    public DeadState DeadState {get; private set;}
    public MonsterAIStateMachine(MonsterAIController controllerInstance)
    {
        m_controllerInstance = controllerInstance;
        m_animation = controllerInstance.m_animation;
        m_body = m_controllerInstance.m_body;
        m_health = m_controllerInstance.m_health;
        m_damage = m_controllerInstance.m_damage;
        m_hitBox = m_controllerInstance.HitBox;
        StateInit();
    }
    private void StateInit()
    {
        DamagedState = new DamagedState(this);
        ChasingState = new ChasingState(this);
        AttackState = new AttackState(this);
        DeadState = new DeadState(this);
        currentState = ChasingState;
    }
}
