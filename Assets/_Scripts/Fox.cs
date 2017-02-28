using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;
	
	void Start()
	{
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject target = collider.gameObject;
		if (!target.GetComponent<Defender>())
		{
			return;
		}
		if (target.GetComponent<Stone>())
		{
			anim.SetTrigger("jump trigger");
		}
		else
		{
			attacker.Attack(target);
		}
	}
}
