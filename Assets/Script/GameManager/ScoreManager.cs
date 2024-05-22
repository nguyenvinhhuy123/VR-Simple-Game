using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private int m_score;
    public int Score { get { return m_score; } }
    private UnityAction<int> m_onAddScore;
    private UnityEvent<int> m_onScoreChange;
    // Start is called before the first frame update
    private void OnEnable()
    {
        m_onAddScore += AddScore;
    }
    void OnDisable()
    {
        m_onAddScore -= AddScore;
    }
    protected override void Awake()
    {
        base.Awake();
        m_onScoreChange = new UnityEvent<int>();
    }
    void Start()
    {
        ResetScore();
    }
    public void ResetScore()
    {
        m_score = 0;
        m_onScoreChange.Invoke(m_score);
    }
    void AddScore(int score)
    {
        m_score += score;
        m_onScoreChange.Invoke(m_score);
    }
    public void ListenToEvent(UnityEvent<int> addScoreEvent)
    {
        addScoreEvent.AddListener(m_onAddScore);
    }
    public void RegisterOnScoreChangedEvent(UnityAction<int> act)
    {
        m_onScoreChange.AddListener(act);
    }
    public void UnregisterOnScoreChangedEvent(UnityAction<int> act)
    {
        m_onScoreChange.RemoveListener(act);
    }
}
