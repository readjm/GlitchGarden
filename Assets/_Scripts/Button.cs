using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour
{
	public GameObject defender;
	public static GameObject selectedDefender;

	private Button[] buttonArray;
	private Text costText;
	
	void Start()
	{
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		costText.text = defender.GetComponent<Defender>().starCost.ToString();
	}
	
	void OnMouseDown()
	{
		foreach(Button thisButton in buttonArray)
		{
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		selectedDefender = defender;
		GetComponent<SpriteRenderer>().color = Color.white;
	}
}
