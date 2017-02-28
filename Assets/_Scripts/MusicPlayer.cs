using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	
	public AudioClip[] trackList;
	private AudioSource audioSource;

	void Awake ()
	{
		Debug.Log("Music Player Awake " + GetInstanceID());
		
		if (instance != null && instance != this)
		{
			
			GameObject.Destroy(gameObject);
			Debug.Log ("Destroyed duplicate Music Player");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			audioSource = GetComponent<AudioSource>();
			
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		Debug.Log("Music Player Start " + GetInstanceID());
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	public void PlayTrack(int track)
	{
		Debug.Log ("Level/track #: " + trackList[track]);
		if (this.GetComponent<AudioSource>().clip != trackList[track])
		{
			this.GetComponent<AudioSource>().clip = trackList[track];
			this.GetComponent<AudioSource>().Play();
		}
	}
	
	void OnLevelWasLoaded(int level)
	{
		if (this.GetComponent<AudioSource>().clip != trackList[level])
		{
			audioSource.clip = trackList[level];
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void SetVolume(float volume)
	{
		audioSource.volume = volume;
	}
	
}
