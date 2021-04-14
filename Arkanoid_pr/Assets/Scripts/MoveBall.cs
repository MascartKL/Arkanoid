using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    //float speed = 5.0f;
    bool active = true;

    Vector2 dir;
    public Rigidbody2D rb;

    void Start()
    {
       
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && active)
		{
            dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            active = false;
        }
        rb.velocity = dir;
    }

    
}
