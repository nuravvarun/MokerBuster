using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PLAYMOV : MonoBehaviour {

	public Button btn;

	/*public MovieTexture movTexture;*/
	void Start() {


		/*movTexture.Play ();*/
	}
	public void taptoplay()

	{
		Application.LoadLevelAsync (1);
	}
	void Update(){
	
		if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
		{
			Application.Quit();
			return;
		}}

}