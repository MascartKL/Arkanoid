using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    BlockDestroy(short hp)
	{
        this.hp = hp;
	}
     
    private short hp = 2;
    public GameObject ball;
    public Sprite[] sprites = new Sprite[2];
    
    void Update()
    {
        if(hp <= 0)
		{
            Debug.Log("Delete");
            //Destroy(this.gameObject);
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.name == "Ball")
        {
            if(--hp > 0)
            ChangeSprite();
        }
    }

    private void ChangeSprite()
	{
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
	}
}
