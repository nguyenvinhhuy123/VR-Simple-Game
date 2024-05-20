using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using UnityEngine.Events;
public class GameManager : Singleton<GameManager>
{
    private GameObject m_player;
    private UnityAction<int, bool> m_onDamagedAction;
    void OnEnable()
    {
        m_onDamagedAction += OnPlayerDamaged;
    }
    void OnDisable()
    {
        m_onDamagedAction -= OnPlayerDamaged;
    }
    protected override void Awake()
    {
        base.Awake();
        m_player = GameObject.FindGameObjectWithTag("Player");

    }
    void Start()
    {
        m_player.GetComponent<Health>().RegisterOnDamagedEvent(m_onDamagedAction);
    }
    void OnPlayerDamaged(int currentHealth, bool isDead)
    {
        if (isDead)
        {
            OnPlayerDead();
        }
    }
    void OnPlayerDead()
    {
        GameOver();
    }
    void GameOver()
    {

    }
}

