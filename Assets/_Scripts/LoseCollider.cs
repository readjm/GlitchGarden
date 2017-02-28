using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public string loseScene;
	
	private LevelManager levelManager;
	
	void Start()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnTriggerEnter2D()
	{
		levelManager.LoadLevel(loseScene);
	}
}
