using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MonsterHealthbar : MonoBehaviour
{

    private Slider m_slider;
    [SerializeField] private Health m_health;
    private UnityAction<int, bool> m_onDamage;
    void Awake()
    {
        m_onDamage += OnDamage;
        m_slider = GetComponent<Slider>();
        m_health = GetComponentInParent<Health>();
    }
    void Start()
    {
        m_health.RegisterOnDamagedEvent(m_onDamage);
        SetMaxValue();
    }
    void SetMaxValue()
    {
        m_slider.maxValue = m_health.MaxHealth;
        m_slider.value = m_slider.maxValue;
    }
    void OnDamage(int currentHealth, bool isDead){
        m_slider.value = currentHealth;
        if(m_slider.value <= 0){
            m_slider.value = 0;
        }
    }
}
