using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAIStateMachine : BaseAIStateMachine
{
    public Rigidbody m_body {get;}
    public Health m_health {get;}
    public Damage m_damage {get;}
    public GameObject m_hitBox {get;}
    //Controller
    public MonsterAIController m_controllerInstance {get;}
    //State initialization
    public MonsterAIStateMachine(MonsterAIController controllerInstance)
    {
        m_controllerInstance = controllerInstance;
        m_body = m_controllerInstance.m_body;
        m_health = m_controllerInstance.m_health;
        m_damage = m_controllerInstance.m_damage;
        m_hitBox = m_controllerInstance.HitBox;
    }
}
