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

    public Sprite[] MainSprites = new Sprite[3];

    public Sprite[] DamageSprites = new Sprite[3];


    private void Start()
    {
        destroy = Resources.Load("desroyBlock") as AudioClip;
        allDestroy = Resources.Load("AllDestroy") as AudioClip;
        if (SceneManager.GetActiveScene().name == "SampleScene") //чтобы на уровнях спавнились блоки определнного цвета
        {
            hp = Random.Range(1, 4); //По идее должно стоять от 1 до 3, но в этом случае он не спавнит третий вид блоков  ¯\_(ツ)_/¯ 
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

            TextView txtView = new TextView(BlockValue.ToString(),gameObject.transform.position);
            txtView.moveText();

            Score.score += BlockValue;

            spavnBonus();
            
            Destroy(gameObject);

            blocks = GameObject.FindGameObjectsWithTag("Block").Length - 1;
            Debug.Log(blocks);           
        }
    }

   private void spavnBonus()
	{
		if (Random.Range(1, 6) == 3)
		{
			Instantiate(Resources.Load("BonusLenght"), gameObject.transform.position, Quaternion.identity);
	    }

		if (Random.Range(1, 10) == 5)
		{
			Instantiate(Resources.Load("BonusDamage"), gameObject.transform.position, Quaternion.identity);
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
