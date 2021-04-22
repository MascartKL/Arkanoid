using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.5f;
    public PressedButton leftButton;
    public PressedButton rightButton;

    void Update()
    {
        if (leftButton.isPressed && checkBord() && transform.position.x > -1.2f)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (rightButton.isPressed && checkBord() && transform.position.x < 1.2f)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    bool checkBord()
    {
    
        if (transform.position.x >= (float)Screen.width/100)
		{
            transform.position += Vector3.left * speed * 0.02f;
            return false;
		}
        if (transform.position.x <= (float)Screen.width / 100*-1)
        {
            transform.position += Vector3.right * speed * 0.02f;
            return false;
        }
        return true;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {
            Destroy(collision.gameObject);
            Debug.Log("Bonus ");
        }
    }
}
