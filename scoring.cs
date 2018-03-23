using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class scoring : MonoBehaviour {

    public GameObject moker;
    public GameObject banana;
    public GameObject bomb;
    public GameObject blast;
    public GameObject menu;
    public GameObject gameover;
	public GameObject explosion;
	public Text finalscore;
	public GameObject sparks;
	public AudioSource clip;
	public GameObject[] life;
    public Text score;
	private int count = 0;

    private int starttime;
    private float resttime = 30;
    private int counttime;
    private int secs;
    public Text timer;
	public Text text1;
	public Text text2;
	public GameObject volumeon;
	public GameObject volumeoff;
	public AudioListener lis;
	public GameObject textprefab;


    GameObject obj;

    public float intervalMin = 3;
    public float intervalMax = 5;


    void Start()
    {
        Spawn();
        menu.SetActive(false);
        gameover.SetActive(false);
		volumeoff.active = false;
		lis=GetComponent<AudioListener>();
    }

    void Update () {

		/* resttime -= Time.deltaTime;
        timer.text = string.Format("{00:00}", resttime);
        if (resttime <= 0)
        {
            gameover.SetActive(true);
			finalscore.text=score.text;
			score.GetComponent<Text>().enabled=false;
			text1.GetComponent<Text>().enabled=false;
			text2.GetComponent<Text>().enabled=false;
			timer.GetComponent<Text>().enabled=false;
            Time.timeScale = 0.0f;

        }*/
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            touche(hit);
        }
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.mousePosition)), Vector2.zero);
            touche(hit);
        }
    }
    void touche(RaycastHit2D hit){


            if (hit.collider.tag == "Enemy")
		{	Handheld.Vibrate();
			float x = hit.collider.gameObject.transform.position.x;
			float y = hit.collider.gameObject.transform.position.y;


			count += 10;
                score.text = "" + count;
	
                

                Destroy(hit.collider.gameObject);

			
                GameObject xx = (GameObject)Instantiate(blast, new Vector2(x, y), Quaternion.identity);
                StartCoroutine(destructing(xx));
            }
            else if (hit.collider.tag == "Bomb")
		{Handheld.Vibrate();
                count -= 50;
                score.text = "" + count;
			if(life[0]!=null)
			{
				Destroy (life[0]);}
			else if(life[1]!=null)
			{Destroy(life[1]);}
			else
			{
				Destroy(life[2]);
				gameover.SetActive(true);
				clip.GetComponent<AudioSource>().mute=true;
				finalscore.text=score.text;
				Time.timeScale = 0.0f;

				score.GetComponent<Text>().enabled=false;
				text1.GetComponent<Text>().enabled=false;
				text2.GetComponent<Text>().enabled=false;
				timer.GetComponent<Text>().enabled=false;
			}	

		
                float x = hit.collider.gameObject.transform.position.x;
                float y = hit.collider.gameObject.transform.position.y;

                Destroy(hit.collider.gameObject);
			    
			    GameObject xx = (GameObject)Instantiate(explosion, new Vector2(x, y), Quaternion.identity);
                StartCoroutine(destructing(xx));
            }
            else if (hit.collider.tag == "Player")
		{Handheld.Vibrate();
                count += 50;
                score.text = "" + count;
		
                float x = hit.collider.gameObject.transform.position.x;
                float y = hit.collider.gameObject.transform.position.y;

                Destroy(hit.collider.gameObject);
                GameObject xx = (GameObject)Instantiate(sparks, new Vector2(x, y), Quaternion.identity);
                StartCoroutine(destructing(xx));
            }
            else if (hit.collider != null)
                switch (hit.collider.name)
                {
                    case "psebtn":
			Handheld.Vibrate();
                        menu.SetActive(true);
                        StartCoroutine(mokerstop());
                        Time.timeScale = 0.0f;
                        menu.SetActive(true);
						clip.GetComponent<AudioSource>().mute=true;
						
			                        break;
					case "Volume1":
			Handheld.Vibrate();
				            lis.enabled=false;
							volumeon.active=false;
							volumeoff.active=true;
                            break;
					case "Volume2":
			Handheld.Vibrate();
                            lis.enabled = true;
							volumeon.active=true;
							volumeoff.active=false;
							break;
                    case "Resumegme":
			Handheld.Vibrate();
						Time.timeScale = 1.0f;
                        menu.SetActive(false);
                        break;
                    case "Restartgme":
			Handheld.Vibrate();
                        Application.LoadLevel("scene1");
                        Time.timeScale = 1.0f;
                        break;
                    case "Quit":
			Handheld.Vibrate();
                        Application.Quit();
                        break;

                }        
    }


    float[] holed = new float[10];
    public float animTime = 1.3f;
    void Spawn()
    {	
        int x = Random.Range(1, 20);
        obj = callingother(x);

        x = Random.Range(1, 10);
        switch (x)
        {
            case 1:
                spawning(0, -1.2f, 9);
                break;
            case 2:
                spawning(1, -6.41f, 4.6f);
                break;
            case 3:
                spawning(2, 4.6f, 4.6f);
                break;
            case 4:
                spawning(3, -12.91f, -0.79f);
                break;
            case 5:
                spawning(4, -1.17f, -2.2f);
                break;
            case 6:
                spawning(5, 10.7f, -0.6f);
                break;
            case 7:
                spawning(6, -18.60f, -8.67f);
                break;
            case 8:
                spawning(7, -7.11f, -9.37f);
                break;
            case 9:
                spawning(8, 5.64f, -8.88f);
                break;
            case 10:
                spawning(9, 16.32f, -9.13f);
                break;
        }
        Invoke("Spawn", Random.Range(intervalMin, intervalMax));
    }


    void spawning(int hol, float xs, float ys)
    {
        if (holed[hol] <= Time.time)
        {
            holed[hol] = Time.time + animTime;
            GameObject x = (GameObject)Instantiate(obj, new Vector2(xs, ys), Quaternion.identity);
            StartCoroutine(destructing(x));
        }
        else
            Spawn();
    }
    IEnumerator destructing(GameObject x)
    {
        yield return new WaitForSeconds(2);
        Destroy(x);
    }


    public GameObject callingother(int i)
    {
        GameObject g;
        if (i <= 3 && i >= 1)
           return bomb;

        else if (i >= 4 && i <= 5)
            return banana;

        else
            return moker;
    }


    IEnumerator mokerstop()
    {
        yield return new WaitForSeconds(0.01f);
        moker.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        banana.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        bomb.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        blast.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }




}
