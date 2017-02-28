using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float timer;
		
	private bool pause = false;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			pause = !pause;
			if (pause)
			{
				Time.timeScale = 0f;
				GameObject.FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Pause();
				return;			
			}
			else
			{
				Time.timeScale = 1f;
				GameObject.FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Play();
			}
		}
		
		if (!pause) timer -= Time.deltaTime;		
		
		if (timer <= 0f)
		{
			GameObject.FindObjectOfType<LevelManager>().LoadNextLevel();
		}
	}
}
