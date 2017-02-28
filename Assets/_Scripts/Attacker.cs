using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour
{
	
	public float attackDamage;
	
	[Tooltip("Average number of seconds between apperances")] 
	public float seenEverySeconds;
	
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		
		if (!currentTarget)
		{
			animator.SetBool("isAttacking", false);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		
	}
	
	public void SetSpeed(float speed)
	{
		currentSpeed = speed;
	}
	
	// Called from animator at time of attack
	public void StrikeCurrentTarget()
	{
		Debug.Log ("Attacker strikes dealing " + attackDamage + " damage!");
		
		if (currentTarget)
		{
			Health targetHealth = currentTarget.GetComponent<Health>();
			if (targetHealth)
			{
				targetHealth.DealDamage(attackDamage);
			}
		}
	}
	
	public void Attack(GameObject target)
	{
		animator.SetBool("isAttacking", true);
		currentTarget = target;
	}
}