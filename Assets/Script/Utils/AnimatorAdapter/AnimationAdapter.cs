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
    [SerializeField] private string IDLE;
    [SerializeField] private string RUN;
    [SerializeField] private string ATTACK;
    [SerializeField] private string DAMAGED;
    [SerializeField] private string DEAD;

    void Awake()
    {
        m_animation = GetComponent<Animation>();
    }
    public void PlayIdle()
    {
        m_animation.Play(IDLE);
    }
    public void PlayRun()
    {
        m_animation.Play(RUN);
    }
    public void PlayAttack()
    {
        m_animation.Play(ATTACK);
    }
    public void PlayDamaged()
    {
        m_animation.Play(DAMAGED);
    }
    public void PlayDead()
    {
        m_animation.Play(DEAD);
    }
    public bool IsPlaying()
    {
        return m_animation.isPlaying;
    }
}
