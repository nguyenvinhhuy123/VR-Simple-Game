using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int m_score;
    public int Score { get { return m_score; } }
    public UnityAction<int> m_onAddScore;
    // Start is called before the first frame update
    private void OnEnable()
    {
        m_onAddScore += AddScore;
    }
    void OnDisable()
    {
        m_onAddScore -= AddScore;
    }
    void Start()
    {
        ResetScore();

    }
    public void ResetScore()
    {
        m_score = 0;
    }
    void AddScore(int score)
    {
        m_score += score;
    }
    public void ListenToEvent(UnityEvent<int> addScoreEvent)
    {
        addScoreEvent.AddListener(m_onAddScore);
    }
}
