using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayerOnDestroy : MonoBehaviour
{
    private Health m_playerHealth;
    [SerializeField] private int m_healAmount;
    void Awake()
    {
    }
    void Start()
    {
        m_playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }
    // Update is called once per frame
    void OnDestroy()
    {
        m_playerHealth.Heal(m_healAmount);
    }
}
