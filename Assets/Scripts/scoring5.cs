using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class scoring5 : MonoBehaviour {

    public GameObject moker;
    public GameObject star;
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
	public Canvas btn1;

    private int starttime;
    private float resttime = 30;
    private int counttime;
    private int secs;
    public Text timer;
	public Text text1;
	public Text text2;
/*	public GameObject volumeon;
	public GameObject volumeoff;*/
	public AudioListener lis;
	public GameObject textprefab;
	public BoxCollider2D psebtn;
	public BoxCollider2D [] colls;





    GameObject obj;

    public float intervalMin = 2;
    public float intervalMax = 20;


    void Start()
	{
		btn1 = btn1.GetComponent<Canvas> ();
		btn1.enabled = false;
        menu.SetActive(false);
        gameover.SetActive(false);
		/* volumeoff.SetActive(false);*/
		lis=GetComponent<AudioListener>();
        spawning(0, -1.2f, 9);
        spawning(1, -6.41f, 4.6f);
        spawning(4, -1.17f, -2.2f);
        spawning(2, 4.6f, 4.6f);
        spawning(3, -12.91f, -0.79f);
        spawning(5, 10.7f, -0.6f);
        spawning(6, -18.60f, -8.67f);
        spawning(7, -7.11f, -9.37f);
        spawning(8, 5.64f, -8.88f);
        spawning(9, 16.32f, -9.13f);
    }

    void Update () {
		if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
		{
			Application.Quit();
			return;
		}

		resttime -= Time.deltaTime;
        timer.text = string.Format("{00:00}", resttime);
        if (resttime <= 0)
        {
           /* gameover.SetActive(true);
			finalscore.text=score.text;
			score.GetComponent<Text>().enabled=false;
			text1.GetComponent<Text>().enabled=false;
			text2.GetComponent<Text>().enabled=false;
			timer.GetComponent<Text>().enabled=false;*/
			Application.LoadLevel(12);

        }
        if (Input.touchCount > 0) {
			Touch[] myTouches = Input.touches;
			for (int i = 0; i < Input.touchCount; i++) {	
				Touch t = Input.GetTouch (i);
				if (t.phase == TouchPhase.Began) {
					RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint ((Input.GetTouch (0).position)), Vector2.zero);
					touche (hit);
				}
			}
		}
        if (Input.GetMouseButtonDown(0)) 
		
		{
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.mousePosition)), Vector2.zero);
            touche(hit);
        }
    }
    void touche(RaycastHit2D hit){
        if (hit.collider.tag == "Enemy")
        {
            
			float x = hit.collider.gameObject.transform.position.x;
			float y = hit.collider.gameObject.transform.position.y;
			count += 10;
            score.text = "" + count;
            Destroy(hit.collider.gameObject);
            GameObject xx = (GameObject)Instantiate(blast, new Vector2(x, y), Quaternion.identity);
            StartCoroutine(destroying(xx));
        }
        else if (hit.collider.tag == "Bomb")
		{
            Handheld.Vibrate();
                count -= 50;
                score.text = "" + count;
			if(life[0]!=null)
				Destroy (life[0]);

			else if(life[1]!=null)
                Destroy(life[1]);

			else
			{
				Destroy(life[2]);
				gameover.SetActive(true);



				btn1.enabled=true;
				clip.GetComponent<AudioSource>().mute=true;
				finalscore.text=score.text;
				Time.timeScale = 0.0f;
				psebtn.enabled=false;
				StartCoroutine(off());
				score.GetComponent<Text>().enabled=false;
				text1.GetComponent<Text>().enabled=false;
				text2.GetComponent<Text>().enabled=false;
				timer.GetComponent<Text>().enabled=false;
			}	

		
                float x = hit.collider.gameObject.transform.position.x;
                float y = hit.collider.gameObject.transform.position.y;

                Destroy(hit.collider.gameObject);
			    
			    GameObject xx = (GameObject)Instantiate(explosion, new Vector2(x, y), Quaternion.identity);
                StartCoroutine(destroying(xx));
            }
            else if (hit.collider.tag == "Player")
		{
                count += 50;
                score.text = "" + count;
		
                float x = hit.collider.gameObject.transform.position.x;
                float y = hit.collider.gameObject.transform.position.y;

                Destroy(hit.collider.gameObject);
                GameObject xx = (GameObject)Instantiate(sparks, new Vector2(x, y), Quaternion.identity);
                StartCoroutine(destroying(xx));
            }
            else if (hit.collider != null)
                switch (hit.collider.name)
                {
                    case "psebtn":

                        menu.SetActive(true);
                        StartCoroutine(mokerstop());
                        Time.timeScale = 0.0f;
                        menu.SetActive(true);
						clip.GetComponent<AudioSource>().mute=true;
			  
						
			                        break;
		/*			case "Volume1":

				            lis.enabled=false;
							volumeon.SetActive(false);
							volumeoff.SetActive(true);
                            break;
					case "Volume2":

                            lis.enabled = true;
							volumeon.SetActive(true);
							volumeoff.SetActive(false);
							break;*/
                    case "Resumegme":

						Time.timeScale = 1.0f;
                        menu.SetActive(false);
			clip.GetComponent<AudioSource>().mute=false;
                        break;
                    case "Restartgme":
			;
                        Application.LoadLevel("scene1");
                        Time.timeScale = 1.0f;
                        break;
                    case "Quit":

                        Application.Quit();
                        break;

                }        
    }


    float[] holed = new float[10];
    public float animTime = 1.3f;
    void Spawn()
    {	
        spawning(0, -1.2f, 9);
        spawning(1, -6.41f, 4.6f);
        spawning(4, -1.17f, -2.2f);
        spawning(2, 4.6f, 4.6f);
        spawning(3, -12.91f, -0.79f);
        spawning(5, 10.7f, -0.6f);
        spawning(6, -18.60f, -8.67f);
        spawning(7, -7.11f, -9.37f);
        spawning(8, 5.64f, -8.88f);
        spawning(9, 16.32f, -9.13f);
                
        Invoke("Spawn", Random.Range(intervalMin, intervalMax));
    }


    void spawning(int hol, float xs, float ys)
    {
        if (holed[hol] <= Time.time)
        {
            
            int i = Random.Range(1, 11);
            if (i <= 5)
            {
                holed[hol] = Time.time + animTime;
                GameObject x = (GameObject)Instantiate(moker, new Vector2(xs, ys), Quaternion.identity);
                StartCoroutine(destructing(x,hol,xs,ys,true));
            }
           else if (i <= 8) { 
                holed[hol] = Time.time + animTime;
                GameObject x = (GameObject)Instantiate(bomb, new Vector2(xs, ys), Quaternion.identity);
                StartCoroutine(destructing(x, hol, xs, ys,true));
            }
            else if (i<= 10)
            {
                holed[hol] = Time.time + animTime;
                GameObject x = (GameObject)Instantiate(star, new Vector2(xs, ys), Quaternion.identity);
                StartCoroutine(destructing(x, hol, xs, ys,true));
            }
            else
                StartCoroutine(destructing(null, hol, xs, ys, false));

        }
    }
    IEnumerator destructing(GameObject x, int hol, float xs, float ys,bool bo)
    {
        yield return new WaitForSeconds(Random.Range(2,4));
        if(bo)
            Destroy(x);
        spawning(hol, xs, ys);
    }
    IEnumerator destroying(GameObject x) {
        yield return new WaitForSeconds(2);
        Destroy(x);
    }


    IEnumerator mokerstop()
    {
        yield return new WaitForSeconds(0.01f);
       /* moker.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        star.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        bomb.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        blast.GetComponent<Rigidbody2D>().velocity = Vector2.zero;*/
		colls [0].enabled = false;
		colls [1].enabled = false;
		colls [2].enabled = false;
	}
	public void back2main()
	{Application.LoadLevel (1);
	}
	IEnumerator off()
	{
		yield return new WaitForSeconds (0.01f);
		colls [0].enabled = false;
		colls [1].enabled = false;
		colls [2].enabled = false;
	}



}
