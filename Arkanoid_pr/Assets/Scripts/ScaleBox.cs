using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBox : MonoBehaviour
{
    public GameObject obj;
    Vector2 col;

    void Start()
    {
        col = obj.GetComponent<BoxCollider2D>().size;
    }

    
    void Update()
    {
        col.x = Screen.width / 100;
        col.y = Screen.height / 100;
    }
}
