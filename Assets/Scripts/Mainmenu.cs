using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mainmenu: MonoBehaviour {
	public Canvas mmenu;
	public Button playtxt;
	public Button settingtxt;
	public Button about;
	public Button exittxt;
	public Canvas can;
	public Button bn;
	public Text hscore;


	public GameObject backpic;
	public Canvas aboutc;
	public Canvas hs;

	// Use this for initialization
	void Start () {
		mmenu = mmenu.GetComponent<Canvas> ();
		aboutc = aboutc.GetComponent<Canvas> ();
		playtxt = playtxt.GetComponent<Button> ();
		settingtxt = settingtxt.GetComponent<Button> ();
		bn = bn.GetComponent<Button> ();
		about = about.GetComponent<Button> ();
		can = can.GetComponent<Canvas> ();
		hs = hs.GetComponent<Canvas> ();
		aboutc.enabled = false;
		can.enabled = false;
		hs.enabled = false;

		if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
		{
			Application.Quit();
			return;
		}
	
	}
	void Update(){
		
		if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
		{
			Application.Quit();
			return;
		}}
	

	public void playpress()
	{
		/*can.enabled = true;
		mmenu.enabled = false;*/
		Application.LoadLevelAsync (2);
	
	}
	public void settingpress()
	{
	}
	public void aboutpress()
	{   
		mmenu.enabled = false; 
		aboutc.enabled = true;


	}
	public void back()
	{
		mmenu.enabled = true;
		aboutc.enabled = false;
	}
	/*public void life()
	{Application.LoadLevel (2);
	}

	public void time()
	{
	Application.LoadLevel(4);
	}*/
	public void bck()
	{
		mmenu.enabled = true;
		can.enabled = false;
	}
	public void exitpress()
	{
		Application.Quit();


	}
	public void showscore()
	{	mmenu.enabled = false;

	hs.enabled = true;
		hscore.text = "" + PlayerPrefs.GetInt ("highscore");
		Debug.Log (PlayerPrefs.GetInt ("highscore"));
	}

}
