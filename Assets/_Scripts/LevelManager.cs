using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	public float autoLoadNextLevelAfter;
	public bool sceneSkippable = false;
	
	private bool pause = false;
	
	void Start()
	{
		//Screen.lockCursor = true;
		//Screen.fullScreen = true;
		
		if (autoLoadNextLevelAfter <= 0f)
		{
			Debug.Log ("Level auto load disabled");
		}
		else
		{
			Debug.Log ("Autoloading level " + (Application.loadedLevel + 1));
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}
	
	void Update()
	{
		if (sceneSkippable && Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log ("Skipping Scene");
			LoadNextLevel();
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			TogglePause();
		}
	}

	public void LoadLevel(string name)
	{
		Debug.Log("Level load requested for : " + name);
		Application.LoadLevel(name);
	}
	
	public void LoadLevel(int level)
	{
		Debug.Log("Level load requested for: " + level);
		
		if (level >= Application.levelCount)
		{
			Screen.showCursor = true;
		}
		Application.LoadLevel(level);		
	}
	
	public void QuitRequest()
	{
		Debug.Log ("Quit requested.");
		Application.Quit();
	}
	
	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void TogglePause()
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

}