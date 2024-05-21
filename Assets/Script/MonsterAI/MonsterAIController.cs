using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AnimationAdapter))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Health))]

public class MonsterAIController : MonoBehaviour
{
    //Component
    public MonsterAIStateMachine m_stateMachine { get; private set; }
    public Rigidbody m_body { get; private set; }
    public AnimationAdapter m_animation { get; private set; }
    public Transform m_playerTransform { get; private set; }
    public Transform m_selfTransform { get; private set; }
    public Health m_health { get; private set; }
    public Damage m_damage { get; private set; }
    [SerializeField] private GameObject m_hitBox;
    public GameObject HitBox { get { return m_hitBox; } }
    [SerializeField] private float m_runSpeed;
    public float RunSpeed { get { return m_runSpeed; } set { m_runSpeed = value; } }
    [SerializeField] private float m_distanceToPlayer;
    public float DistanceToPlayer { get { return m_distanceToPlayer; } set { m_distanceToPlayer = value; } }
    [SerializeField] private float m_attackRange;
    public float AttackRange { get { return m_attackRange; } set { m_attackRange = value; } }
    [SerializeField] private float m_attackRate;
    public float AttackRate { get { return m_attackRate; } set { m_attackRate = value; } }
    public UnityAction<int, bool> OnDamagedAction;
    void OnEnable()
    {
        OnDamagedAction += OnDamage;
    }
    void OnDisable()
    {
        OnDamagedAction -= OnDamage;
    }

    void Awake()
    {
        m_body = GetComponent<Rigidbody>();
        m_animation = GetComponent<AnimationAdapter>();
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        m_selfTransform = gameObject.transform;
        m_health = GetComponent<Health>();
        m_damage = GetComponent<Damage>();
    }

    void Start()
    {
        m_stateMachine = new MonsterAIStateMachine(this);
        m_health.RegisterOnDamagedEvent(OnDamagedAction);
    }
    void Update()
    {
        // m_stateMachine.PrintCurrentState();
        m_stateMachine.OnUpdate();
    }
    void FixedUpdate()
    {
        m_distanceToPlayer = CalculateDistanceToPlayer();
        m_stateMachine.OnFixedUpdate();
    }
    public void OnDamage(int currentHealth, bool isDead)
    {
        if (isDead) { OnDead(); }
        else
        {
            m_stateMachine.OnChangeState(m_stateMachine.DamagedState);
        }
    }
    public void OnDead()
    {
        m_stateMachine.OnChangeState(m_stateMachine.DeadState);
    }
    public float CalculateDistanceToPlayer()
    {
        return Vector3.Distance(
            m_playerTransform.position,
        m_selfTransform.position);
    }
}
