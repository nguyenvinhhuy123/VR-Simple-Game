using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animator Adapter for AIStateMachine 
/// to play animation regardless of animator and animation clip set up
/// </summary> 
public class AnimationAdapter : MonoBehaviour
{
    private Animation m_animation;
    private Animator m_animator;
    [SerializeField] private string IDLE;
    [SerializeField] private string RUN;
    [SerializeField] private string ATTACK;
    [SerializeField] private string DAMAGED;
    [SerializeField] private string DEAD;

    void Awake()
    {
        m_animation = GetComponent<Animation>();
        m_animator = GetComponent<Animator>();
    }
    void Update()
    {
    }
    public void PlayIdle()
    {
        if (m_animator != null)
        {
            m_animator.Play(IDLE, 0, 0f);
            return;
        }
        m_animation.Play(IDLE);
    }
    public void PlayRun()
    {
        if (m_animator != null)
        {
            m_animator.Play(RUN, 0, 0f);
            return;
        }
        m_animation.Play(RUN);
    }
    public void PlayAttack()
    {
        Debug.Log("PlayAttack");
        if (m_animator != null)
        {
            m_animator.Play(ATTACK, 0, 0f);
            return;
        }
        m_animation.Play(ATTACK);
    }
    public void PlayDamaged()
    {
        if (m_animator != null)
        {
            m_animator.Play(DAMAGED, 0, 0f);
            return;
        }
        m_animation.Play(DAMAGED);
    }
    public void PlayDead()
    {
        if (m_animator != null)
        {
            m_animator.Play(DEAD, 0, 0f);
            return;
        }
        m_animation.Play(DEAD);
    }
    public bool IsPlaying()
    {
        if (m_animator != null)
        {
            return m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
        }
        return m_animation.isPlaying;
    }
}
