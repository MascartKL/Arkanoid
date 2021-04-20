using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    public Lines(byte countBlocks, float PosY, GameObject gameObject)
	{
        this.countBlocks = countBlocks;
        this.PosY = PosY;
        this.gameObject = gameObject;
	}

    private GameObject gameObject;
    public byte countBlocks;
    private float PosY;
    private Vector3 position;



    public void CreateLinesBlock()
	{
        for(int i = 0; i < countBlocks; i++)
		{
            position.x = (float)Screen.width / 240 * -1 + i*0.6f;
            position.z = 0;
            position.y = PosY;
            Instantiate(gameObject, position, Quaternion.identity);
        }
    }
    
}
