using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreTextController : MonoBehaviour
{
    [SerializeField] private TMP_Text m_textObj;
    private UnityAction<int> m_onScoreChangeAction;
    void OnEnable()
    {
        m_onScoreChangeAction += SetScoreText;
    }
    void OnDisable()
    {
        m_onScoreChangeAction -= SetScoreText;
    }
    void Start()
    {
        ScoreManager.Instance.RegisterOnScoreChangedEvent(m_onScoreChangeAction);
    }
    public void SetScoreText(int score)
    {
        Debug.Log(score);
        string text = "Score: " + score.ToString();
        m_textObj.SetText(text);
    }
}
