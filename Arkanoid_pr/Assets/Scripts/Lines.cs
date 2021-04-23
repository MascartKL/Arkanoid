using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    public Lines(byte countBlocks, float PosY, GameObject gameObject)
	{
        this.countBlocks = countBlocks;
        this.PosY = PosY;
        block = gameObject;
	}

    private GameObject block;
    private Vector3 position;

    public List<GameObject> gameObjects = new List<GameObject>();
    private byte countBlocks;
    private float PosY;



    public void CreateLinesBlock()
	{
        for(byte i = 0; i < countBlocks; i++)
		{
            position.x = 1.5f * -1 + i*0.6f;
            position.z = 0;
            position.y = PosY;
            gameObjects.Add(Instantiate(block, position, Quaternion.identity));
        }
    }
}
