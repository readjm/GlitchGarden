using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{
	public float levelTimeInSeconds;
		
	private Slider timer;
	private bool levelComplete = false;
	private GameObject winText; 
	
	void Start()
	{
		timer = GetComponent<Slider>();
		
		winText = GameObject.Find("Win Text");
		winText.SetActive(false);
	}
	
	void Update()
	{
		timer.value = Time.timeSinceLevelLoad / levelTimeInSeconds;
		
		if (timer.value >= 1f && !levelComplete)
		{
			HandleWindCondition();
		}
	}
	
	void HandleWindCondition()
	{
		DestroyAllTaggedObjects();
		GetComponent<AudioSource>().Play();
		levelComplete = true;
		winText.SetActive(true);
		Invoke("LoadNextLevel", GetComponent<AudioSource>().clip.length);
		
	}
	
	void DestroyAllTaggedObjects()
	{
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");
		foreach (GameObject taggedObject in taggedObjectArray)
		{
			Destroy (taggedObject);
		}
	}
	
	private void LoadNextLevel()
	{
		GameObject.FindObjectOfType<LevelManager>().LoadNextLevel();
	}
	
	
}
