using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    private short hp = 3;
    public GameObject ball;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(hp <= 0)
		{
            Destroy(this.gameObject);
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log("Он во мне...");
        if (collision.gameObject.name == "Ball")
        {
            hp--;
        }
    }
}
