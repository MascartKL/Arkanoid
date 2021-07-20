using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlockDestroy : MonoBehaviour
{
    [SerializeField]
    private int  hp;
    private int BlockValue;
    private AudioClip destroy, allDestroy;

    public static int blocks;

    public byte numberLine;

    public GameObject ball;

    public Sprite[] MainSprites = new Sprite[4];

    public Sprite[] DamageSprites = new Sprite[3];

    static public int lowLimitHP = 1;
    static public int upLimitHP = 4;
    static private int hpupnum;

    private int blocktype;


    private void Start()
    {
        hpupnum = 0;
        lowLimitHP = 4;
        upLimitHP = 7;
        destroy = Resources.Load("desroyBlock") as AudioClip;
        allDestroy = Resources.Load("AllDestroy") as AudioClip;
        if (SceneManager.GetActiveScene().name == "SampleScene") //чтобы на уровнях спавнились блоки определнного цвета
        {
            //hp = Random.Range(1, 4); //По идее должно стоять от 1 до 3, но в этом случае он не спавнит третий вид блоков  ¯\_(ツ)_/¯ 
            hp = Random.Range(lowLimitHP, upLimitHP);
        }
        numberLine = (byte)Mathf.Round(3.3f % gameObject.transform.position.y / 0.3f);
        BlockColour();

        blocks = GameObject.FindGameObjectsWithTag("Block").Length - 1;
    }
 

    
    void Update()
    {
        BlockStatus();
        if(hp <= 0)
		{
            if (SceneManager.GetActiveScene().name == "SampleScene")// см. выше
            {
                CreateLineBlocks.BlockInLinesRemove(numberLine, gameObject);
            }

            if(Move.isBonusScore == true)
            {
                TextView txtView = new TextView((BlockValue * 2).ToString(), gameObject.transform.position);
                txtView.moveText();
                Score.score += BlockValue * 2;
            }
            else
            {
                TextView txtView = new TextView(BlockValue.ToString(), gameObject.transform.position);
                txtView.moveText();
                Score.score += BlockValue;
            }

            spavnBonus();
            
            Destroy(gameObject);

            if(SceneManager.GetActiveScene().buildIndex == 1 && Score.score % 10 == 0)
            {
                if (Score.score <= 100)
                {
                    MoveBall.BallSpeed += 0.1f;            //Score.score / 20;
                    Debug.Log("move is " + MoveBall.BallSpeed);
                }
                else
                    MoveBall.BallSpeed += 0.05f;            //Score.score / 1000;
            }

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                if((Score.score >= 100) && (Score.score < 200) && (hpupnum == 0))
                {
                    lowLimitHP += 1;
                    Debug.Log("test is ok");
                    hpupnum += 1;
                    Debug.Log("hpupnum = " + hpupnum);
                    //upLimitHP += 1;
                }
                else if(Score.score >= 200 && Score.score < 300 && hpupnum == 1)
                {
                    lowLimitHP += 1;
                    hpupnum += 1;
                }
                else if(Score.score >= 300 && Score.score < 400 && hpupnum == 2)
                {
                    upLimitHP += 1;
                    hpupnum += 1;
                }
                else if (Score.score >= 400 && Score.score < 500 && hpupnum == 3)
                {
                    lowLimitHP += 1;
                }



            }

                blocks = GameObject.FindGameObjectsWithTag("Block").Length - 1;
            Debug.Log(blocks);           
        }
    }

   private void spavnBonus()
	{
        if (GameObject.FindGameObjectsWithTag("BonusLenght").Length == 0)
        {
            if (Random.Range(1, 6) == 3)
            {
                Instantiate(Resources.Load("BonusLenght"), gameObject.transform.position, Quaternion.identity);
            }
        }

        if (GameObject.FindGameObjectsWithTag("BonusDamage").Length == 0)
        {
            if (Random.Range(1, 10) == 5)
            {
                Instantiate(Resources.Load("BonusDamage"), gameObject.transform.position, Quaternion.identity);
            }
        }
        if (GameObject.FindGameObjectsWithTag("BonusScore").Length == 0)
        {
            if (Random.Range(1, 12) == 5)
            {
                Instantiate(Resources.Load("BonusScore"), gameObject.transform.position, Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.name == "Ball")
        {
              hp -= MoveBall.damageBall;
            if(hp > 0)
			{
                collision.gameObject.GetComponent<AudioSource>().volume = 1f;
                collision.gameObject.GetComponent<AudioSource>().PlayOneShot(destroy);
                CreateLineBlocks.CheckOffset(Move.countHit++);
            }
            else
			{
                collision.gameObject.GetComponent<AudioSource>().volume = 0.7f;
                collision.gameObject.GetComponent<AudioSource>().PlayOneShot(allDestroy);
                CreateLineBlocks.CheckOffset(Move.countHit++);
            }
        }
    }

    private void BlockStatus()
    {        
        switch(blocktype)
        {
            case 2:
                {
                    switch (hp)
                    {
                        case 2:
                            gameObject.GetComponent<SpriteRenderer>().sprite = MainSprites[1];
                            break;
                        case 1:
                            gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[0];
                            break;
                    }
                    break;
                }
            case 3:
                {
                    switch (hp)
                    {
                        case 2:
                            gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[1];
                            break;
                        case 1:
                            gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[2];
                            break;
                    }
                    break;
                }
            case 4:
                switch (hp)
                {
                    case 3:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[3];
                        break;
                    case 2:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[4];
                        break;
                    case 1:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[5];
                        break;
                }
                break;
            case 5:
                switch (hp)
                {
                    case 4:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[6];
                        break;
                    case 3:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[7];
                        break;
                    case 2:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[8];
                        break;
                    case 1:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[9];
                        break;
                }
                break;
            case 6:
                switch (hp)
                {
                    case 5:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[10];
                        break;
                    case 4:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[11];
                        break;
                    case 3:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[12];
                        break;
                    case 2:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[13];
                        break;
                    case 1:
                        gameObject.GetComponent<SpriteRenderer>().sprite = DamageSprites[14];
                        break;
                }
                break;
        }
    }
    private void BlockColour()
    {
        switch (hp)
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = MainSprites[0];
                blocktype = 1;
                BlockValue = 1;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = MainSprites[1];
                blocktype = 2;
                BlockValue = 2;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = MainSprites[2];
                blocktype = 3;
                BlockValue = 3;
                break;
            case 4:
                gameObject.GetComponent<SpriteRenderer>().sprite = MainSprites[3];
                blocktype = 4;
                BlockValue = 4;
                break;
            case 5:
                gameObject.GetComponent<SpriteRenderer>().sprite = MainSprites[4];
                blocktype = 5;
                BlockValue = 5;
                break;
            case 6:
                gameObject.GetComponent<SpriteRenderer>().sprite = MainSprites[5];
                blocktype = 6;
                BlockValue = 6;
                break;
            default:
                gameObject.GetComponent<SpriteRenderer>().sprite = MainSprites[2];
                blocktype = 3;
                BlockValue = 3;
                break;

        }
    }
}
