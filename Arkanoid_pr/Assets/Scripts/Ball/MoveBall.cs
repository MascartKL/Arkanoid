using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
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
    private float BallSpeed = 2f;
    private AudioClip sound;

    public static int damageBall = 1;

	private void Awake()
	{
        sound = Resources.Load("rebound") as AudioClip;  
    }

	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Board")
        {
            Svdir = new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f));
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


