﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{

    private int hp;
    private int BlockValue;
    public GameObject ball;

    public Sprite[] MainSprites = new Sprite[3];

    public Sprite[] DamageSprites = new Sprite[3];

    private void Awake()
    {
        hp = Random.Range(1, 4); //По идее должно стоять от 1 до 3, но в этом случае он не спавнит третий вид блоков  ¯\_(ツ)_/¯
    }
    void Start()
    {
        BlockColour();
    }

    
    void Update()
    {
        BlockStatus();
        if(hp <= 0)
		{
            Destroy(this.gameObject);
            Score.score += BlockValue;
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

    private void BlockStatus()
    {
        if(gameObject.GetComponent<SpriteRenderer>().sprite == MainSprites[1] && hp==1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[0];
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite == MainSprites[2] || gameObject.GetComponent<SpriteRenderer>().sprite == DamageSprites[1])
        {
            switch (hp)
            {

                case 1:
                    gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[2];
                    Debug.Log("test");
                    break;
                case 2:
                    gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[1];
                    break;
            }
        }
    }
    private void BlockColour()
    {
        switch (hp)
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = MainSprites[0];
                BlockValue = 1;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = MainSprites[1];
                BlockValue = 2;
                break;
            default:
                gameObject.GetComponent<SpriteRenderer>().sprite = MainSprites[2];
                BlockValue = 3;
                break;

        }
    }
}
