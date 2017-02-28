using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private Camera gameCamera;
	private GameObject defenderParent;
	private StarDisplay starDisplay;
	
	void Start()
	{
		gameCamera = GameObject.FindObjectOfType<Camera>();
		
		defenderParent = GameObject.Find("Defenders");
		if (!defenderParent)
		{
			defenderParent = new GameObject("Defenders");
		}
		
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();	
	}
	
	void OnMouseDown()
	{
		int defenderCost = Button.selectedDefender.GetComponent<Defender>().starCost;		
		
		if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
		{
			GameObject newDefender = Instantiate(Button.selectedDefender) as GameObject;
			newDefender.transform.parent = defenderParent.transform;
			newDefender.transform.position = SnapToGrid(MouseClickToWorldPoint());
		}
		else
		{
			Debug.Log ("Insufficient stars");
		}
	}
	
	Vector2 MouseClickToWorldPoint()
	{
		return (Vector2)gameCamera.ScreenToWorldPoint(Input.mousePosition);
	}
	
	Vector2 SnapToGrid(Vector2 rawVector)
	{
		//return new Vector2(Mathf.Floor(rawVector.x + .5f), Mathf.Floor (rawVector.y + .5f));
		return new Vector2(Mathf.RoundToInt(rawVector.x), Mathf.RoundToInt(rawVector.y));
	}
}
