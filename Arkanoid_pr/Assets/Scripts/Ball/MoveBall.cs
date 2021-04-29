using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    Vector2 dir;
    bool active = false;

    private Rigidbody2D rb;
    private float BallSpeed = 100f;
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
            dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            active = true;
            rb.AddForce(dir * BallSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Board")
        {
            if(Random.Range(1,3) == 1)
			{
                rb.velocity = new Vector2(gameObject.transform.position.x * -1f, gameObject.transform.position.y);
            }
            else
			{
                rb.velocity = new Vector2(gameObject.transform.position.x * 1f, gameObject.transform.position.y);
            }
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


