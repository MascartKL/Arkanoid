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
        if (leftButton.isPressed  && transform.position.x > -1.2f)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (rightButton.isPressed  && transform.position.x < 1.2f)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
