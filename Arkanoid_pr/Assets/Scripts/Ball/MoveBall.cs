using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBall : MonoBehaviour
{
    public Sprite[] ballSprite = new Sprite[3];
    private Vector2 dir;

	private Vector2 Svdir
	{
		get
		{
			return dir;
		}
		set
		{
            if (value.y > 2f)
            {
              value.y = 2f;
            }
            if(value.y < 1f)
			{
               value.y = 1f;
            }
            if(value.x > 0 && value.x < 1f)
			{
                value.x = 1f;
            }
            if (value.x < 0 && value.x > -1f)
            {
                value.x = -1f;
            }
            dir.y = value.y;
            dir.x = value.x;
        }
	}


	bool active = false;

    private Rigidbody2D rb;
    static  public float BallSpeed = 2.0f;
    private AudioClip sound;

    public static int damageBall = 1;

	private void Awake()
	{
        sound = Resources.Load("rebound") as AudioClip;  
    }

	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damageBall = PlayerPrefs.GetInt("upDamage") +1;
        BallSpeed = 2.0f;
        Debug.Log("damage = " + damageBall);

        switch(LevelScore.numBallCh)
        {
            case 1:
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = ballSprite[0];
                    break;
                }
            case 2:
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = ballSprite[1];
                    break;
                }
            case 3:
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = ballSprite[2];
                    break;
                }
            default:
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = ballSprite[0];
                    break;
                }
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !active)
        {
            Svdir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Debug.Log(Svdir);
            active = true;
            rb.velocity = Svdir * BallSpeed;
        }
        /*if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Score.score <= 100)
                BallSpeed += Score.score / 10;
            else if (Score.score > 100)
                BallSpeed += Score.score / 100;
        }*/
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Board")
        {
            Svdir = new Vector2(Random.Range(2.5f, 2.5f), Random.Range(2.5f, 2.5f));
            rb.velocity = Svdir * BallSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Top" 
            || collision.gameObject.name == "Right"
            || collision.gameObject.name == "Left"
            || collision.gameObject.name == "Board")
        {
            gameObject.GetComponent<AudioSource>().volume = 0.3f;
            gameObject.GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
}


