using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MonsterAIController : MonoBehaviour
{
    //Component
    public MonsterAIStateMachine m_stateMachine {get; private set; }
    public Rigidbody m_body {get; private set; }
    public Animator m_animator {get; private set; }
    public Transform m_playerTransform {get; private set; }
    public Health m_health {get; private set; }
    public Damage m_damage {get; private set; }
    [SerializeField] private GameObject m_hitBox;
    public GameObject HitBox {get {return m_hitBox;}}
    [SerializeField] private float m_runSpeed; 
    public float RunSpeed {get {return m_runSpeed;} set {m_runSpeed = value;}}

    [SerializeField] private float m_attackRange; 
    public float AttackRange {get {return m_attackRange;} set {m_attackRange = value;}}

    [SerializeField] private float m_attackRate; 
    public float AttackRate {get {return m_attackRate;} set {m_attackRate = value;}}

    public UnityAction<int, bool> OnDamagedAction;

    void Awake()
    {
        m_body = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        m_health = GetComponent<Health>();
        m_damage = GetComponent<Damage>();
    }
    void Start()
    {
        m_stateMachine = new MonsterAIStateMachine(this);
    }
    public void OnDamage(int currentHealth, bool isDead)
    {
        if (isDead) {OnDead();}
        else 
        {

        }
    }
    public void OnDead()
    {

    }
}
