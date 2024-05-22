using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddScoreOnDestroy : MonoBehaviour
{
    [SerializeField] private int scoreToAdd;
    private UnityEvent<int> m_onDestroy;
    void Awake()
    {
        m_onDestroy = new UnityEvent<int>();
    }
    void Start()
    {
        ScoreManager.Instance.ListenToEvent(m_onDestroy);
    }
    // Update is called once per frame
    void OnDestroy()
    {
        m_onDestroy.Invoke(scoreToAdd);
    }
}
