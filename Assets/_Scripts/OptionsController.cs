﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager LevelManager;
	
	private MusicPlayer musicPlayer;
	
	void Start ()
	{
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
		
	}
	
	void Update ()
	{
		musicPlayer.SetVolume(volumeSlider.value);
	}
	
	public void SaveAndExit()
	{
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		musicPlayer.SetVolume(volumeSlider.value);

		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		
		LevelManager.LoadLevel("01a Start");
	}
	
	public void SetDefaults()
	{
		volumeSlider.value = .8f;
		difficultySlider.value = 2f;
	}
}
