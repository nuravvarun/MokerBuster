
using UnityEngine;
using System.Collections;

public class bhvscript : MonoBehaviour {

	public GameObject moker;
	public GameObject banana;
	public GameObject bomb;
    GameObject obj;

	public float m;
	public float n;

	public int intervalMin = 3;
	public int intervalMax = 10;
    void Start () {

		Invoke("Spawn", Random.Range(intervalMin, intervalMax));
	
	}
	
	// Update is called once per frame
	void Spawn () {

		int x = Random.Range (1, 5);

		obj = callingother (x);
			
		Instantiate(obj,new Vector2(m,n), Quaternion.identity);

		Invoke ("Spawn", Random.Range (intervalMin, intervalMax));
      
	}
	public GameObject callingother(int i)
	{
		GameObject g;
		if (i <= 3 && i >= 1) {
			g = bomb;
			return g;
		} else 
			if (i >= 4 && i <= 5) {
			g = banana;
			return g;
		}
		else 
			g = moker;
		return g;	
	}
	
}

