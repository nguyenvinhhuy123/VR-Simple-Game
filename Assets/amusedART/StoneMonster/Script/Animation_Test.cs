using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Test : MonoBehaviour {

	[Range(1,5)][SerializeField] private int m_current;
	public const string IDLE	= "Anim_Idle";
	public const string RUN		= "Anim_Run";
	public const string ATTACK	= "Anim_Attack";
	public const string DAMAGE	= "Anim_Damage";
	public const string DEATH	= "Anim_Death";

	[SerializeField] Animation anim;
	void Awake()
	{
		anim = GetComponent<Animation>();
	}
	
	public void IdleAni (){
		anim.CrossFade (IDLE);
	}

	public void RunAni (){
		anim.CrossFade (RUN);
	}

	public void AttackAni (){
		anim.CrossFade (ATTACK);
	}

	public void DamageAni (){
		anim.CrossFade (DAMAGE);
	}

	public void DeathAni (){
		anim.CrossFade (DEATH);
	}

	void OnValidate()
	{
		switch (m_current)
		{
			case 1:
			{
				RunAni();
				break;
			}

			case 2:
			{
				AttackAni();
                break;
			}
			case 3:
			{
				DamageAni();
                break;
			}
			case 4:
			{
				DeathAni();
                break;
			}
			default:
			{
				IdleAni();
                break;
			}
		}
	}
}
