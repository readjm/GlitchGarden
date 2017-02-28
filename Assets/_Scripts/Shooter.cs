using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{	
	public GameObject projectile;
	public GameObject gun;

	private GameObject projectileParent;
	private Animator animator;
	private AttackerSpawner attackerSpawner;
	
	void Start()
	{
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent)
		{
			projectileParent = new GameObject("Projectiles");
		}
		
		animator = GetComponent<Animator>();
		
		FindSpawnerInLane();
	}
	
	void Update()
	{
		if (IsAttackerAhead())
		{
			animator.SetBool("isAttacking", true);
		}
		else
		{
			animator.SetBool("isAttacking", false);
		}	
	}
	
	public void FireGun()
	{
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	
	private void FindSpawnerInLane()
	{
		AttackerSpawner[] attackerSpawners = GameObject.FindObjectsOfType<AttackerSpawner>();
		foreach(AttackerSpawner spawner in attackerSpawners)
		{
			if (spawner.transform.position.y == gameObject.transform.position.y)
			{
				attackerSpawner = spawner;
				return;
			}
		}
		Debug.Log ("No spawner found in lane");
	}
	
	private bool IsAttackerAhead()
	{
		if (attackerSpawner.transform.childCount <= 0)
		{
			return false;
		}
		
		foreach(Transform attackerTransform in attackerSpawner.transform)
		{
			if (attackerTransform.transform.position.x >= gameObject.transform.position.x)
			{
				return true;
			}
		}		
		
		return false;
	}
	
}
