using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour
{

	public GameObject[] attackerPrefabArray;	
	
	private GameObject attackerParent;
	
	void Start()
	{
		attackerParent = GameObject.Find("Defenders");
		if (!attackerParent)
		{
			attackerParent = new GameObject("Defenders");
		}		
	}
	
	void Update()
	{
		foreach (GameObject attackerPrefab in attackerPrefabArray)
		{
			if (IsTimeToSpawn(attackerPrefab))
			{
				Spawn (attackerPrefab);
			}
		}
	}
	
	bool IsTimeToSpawn(GameObject attackerPrefab)
	{
		Attacker attacker = attackerPrefab.GetComponent<Attacker>();
		
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1f / meanSpawnDelay;
				
		if (Time.deltaTime > meanSpawnDelay)
		{
			Debug.Log("Warning: Spawn rate capped by frame rate");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
				
		return (Random.value < threshold);
	}
	
	void Spawn(GameObject attackerPrefab)
	{
		GameObject newAttacker = Instantiate(attackerPrefab) as GameObject;
		newAttacker.transform.parent = gameObject.transform;
		newAttacker.transform.position = gameObject.transform.position;
	}
}