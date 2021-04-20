using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    Vector2 dir;

    bool active = false;
    public Rigidbody2D rb;
    private float BallSpeed = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& !active)
		{
            dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            active = true;
           rb.AddForce(dir * BallSpeed);  
        }
    }

    private void OnTriggerEnter(BoxCollider2D DeatZone)
    {
        Destroy(gameObject);
    }

}
