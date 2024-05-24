using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using UnityEngine.Events;
public class GameManager : Singleton<GameManager>
{
    private GameObject m_player;
    private UnityAction<int, bool> m_onDamagedAction;
    private UnityEvent m_onGameOver;
    [SerializeField] private GameObject m_gameOverPanelObject;
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
        m_onGameOver = new UnityEvent();
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
        Time.timeScale = 0f;
        m_gameOverPanelObject.SetActive(true);
        m_onGameOver.Invoke();
    }
    public void RegisterOnGameOverEvent(UnityAction action)
    {
        m_onGameOver.AddListener(action);
    }
    public void UnregisterOnGameOverEvent(UnityAction action)
    {
        m_onGameOver.RemoveListener(action);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneLoader.Instance.LoadGamePlay();
    }
    public void QuitGame()
    {
        SceneLoader.Instance.QuitGame();
    }
}

