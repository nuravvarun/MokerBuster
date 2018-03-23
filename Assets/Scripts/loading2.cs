using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loading2 : MonoBehaviour {

/*	public Text ti;
	public float tme=5;
	


	IEnumerator Start() {
	
		yield return new WaitForSeconds (3);

			AsyncOperation async = Application.LoadLevelAsync(3);
			yield return async;
			Debug.Log("Loading complete");
		}
	void Update(){
		if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
		{
			Application.Quit();
			return;
		}
		tme -= Time.deltaTime;

		ti.text = string.Format ("{00:00}", tme);
	}

	*/

	public float speed;
	public float count;
	public Text t1;
	public Text t2;
	public Canvas c1;
	public Canvas c2;
	public GameObject g;
	public int a;




	IEnumerator Start()
	{
		c1 = c1.GetComponent<Canvas> ();
		/*c1.enabled = false;
		t1.enabled = false;



		c1.enabled = true;*/
		t2.enabled = false;

		AsyncOperation async = Application.LoadLevelAsync(a);
		yield return async;
		t1.enabled = true;
		yield return new WaitForSeconds (1);
		Destroy (t1);
		t2.enabled = true;
		yield return new WaitForSeconds (1);
		Destroy (t2);
	

		/*AsyncOperation async = Application.LoadLevelAsync(a);
		yield return async;*/
	}

		void Update()
		{

	
			
			if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
			{
				Application.Quit();
				return;
			}
		/*if (Application.GetStreamProgressForLevel (3) == 1) {

			
			Start ();
			GetComponent<Animator>().Play("lodinbar");
		}*/
	}

	/*public void play() 
	{  

		StartCoroutine (startplay ());
	
	
	}
	IEnumerator startplay()
	{   g.SetActive (false);
		c2.enabled = false;
		c1.enabled = true;
		t1.enabled = true;
		yield return new WaitForSeconds (1);
		Destroy (t1);
		t2.enabled = true;
		yield return new WaitForSeconds (1);
		Destroy (t2);
		AsyncOperation async = Application.LoadLevelAsync(3);
		yield return async;
		
	}*/
}
