using UnityEngine;
using System.Collections;

public class ClickMe : MonoBehaviour {

	public int PointsToGivePlayer;
	public string TextToShow;
	public GameObject textabve;

	public void OnMouseDown ()
	{
		SpawnText ();
	}

	public void SpawnText() 
	{
		GameObject PointsText = Instantiate(textabve) as GameObject;
		
		if(PointsText.GetComponent<TextOnSpotScript>() != null) {
			
			var givePointsText = PointsText.GetComponent<TextOnSpotScript>();
			givePointsText.DisplayPoints = PointsToGivePlayer;
			givePointsText.DisplayText = TextToShow;
			
		}
		PointsText.transform.position = gameObject.transform.position;
	}
}
