using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int m_Health;
    public int MaxHealth {get {return m_Health;} set {m_Health = value;}}
    //*Track Current health of this obj*/
    [SerializeField] private int m_CurrentHealth;
    [SerializeField] private float m_IFrameTime;
    public float IFrameTime {get {return m_IFrameTime;} set {m_IFrameTime = value;}}
    private float m_IFrameTimer;
    /*
    *m_damageEvent<currentHealth: int, isDead_:bool>
    */
    private UnityEvent<int, bool> m_onDamagedEvent;

    /*
    *m_healEvent<currentHealth: int>
    */
    private UnityEvent<int> m_onHealEvent;
    void Awake()
    {
        m_onDamagedEvent = new UnityEvent<int, bool>();
        m_onHealEvent = new UnityEvent<int>();
        ResetHealth();
    }
    void Update()
    {
        //Update timer call for IFrameTimer
        m_IFrameTimer -= Time.deltaTime; 
    }
    /// <summary>
    /// Reset this obj current health to max_health
    /// </summary>
    public void ResetHealth()
    {
        m_CurrentHealth = m_Health;
    } 
    /// <summary>
    /// Method to call when damage this damageable from outer source
    /// </summary>
    /// <param name="inputDamage">taken damage</param>
    /// <param name="source">dmg source</param>
    public void Damaged(int inputDamage, Damage source)
    {
        bool isDead = false;
        if (m_IFrameTimer >= 0f)
        {
            return;
        } 
        m_CurrentHealth -= inputDamage;
        if (m_CurrentHealth <= 0)
        {
            m_CurrentHealth = 0;
            isDead =true;
        }
        m_onDamagedEvent.Invoke(m_CurrentHealth, isDead);
        if (isDead) return;
        m_IFrameTimer = m_IFrameTime;
    }
    public void Heal(int healAmount)
    {
        m_CurrentHealth += healAmount;
        if (m_CurrentHealth >= m_Health)
        {
            ResetHealth();
        }
        m_onHealEvent.Invoke(m_CurrentHealth);
    }
    public void RegisterOnDamagedEvent(UnityAction<int, bool> act)
    {
        m_onDamagedEvent.AddListener(act);
    }

    public void UnRegisterOnDamagedEvent(UnityAction<int, bool> act)
    {
        m_onDamagedEvent.RemoveListener(act);
    }
}
