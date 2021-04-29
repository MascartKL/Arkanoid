using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BlockDestroy : MonoBehaviour
{
    private int hp;
    private int BlockValue;
    private AudioClip destroy, allDestroy;


    public static byte numberLine;

    public GameObject ball;

    public Sprite[] MainSprites = new Sprite[3];

    public Sprite[] DamageSprites = new Sprite[3];

    private void Awake()
    {
        // bonusLenght = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/BonusLenght.prefab", typeof(GameObject));
        //bonusLenght = Resources.Load<GameObject>("Assets/Prefabs/BonusLenght");
        destroy = Resources.Load("desroyBlock") as AudioClip;
        allDestroy = Resources.Load("AllDestroy") as AudioClip;
        hp = Random.Range(1, 4); //По идее должно стоять от 1 до 3, но в этом случае он не спавнит третий вид блоков  ¯\_(ツ)_/¯ 
        if(gameObject.transform.position.y == 3.3f)
		{
            numberLine = 0;
		}
        if (gameObject.transform.position.y == 3.0f)
        {
            numberLine = 1;
        }
        else 
        {
            numberLine = 2;
        }
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
            CreateLineBlocks.BlockInLinesRemove(numberLine, this.gameObject);

            TextView txtView = new TextView(BlockValue.ToString(),gameObject.transform.position);
            txtView.moveText();

            Score.score += BlockValue;

            spavnBonus();

            Destroy(gameObject);
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
            }
            else
			{
                collision.gameObject.GetComponent<AudioSource>().volume = 0.7f;
                collision.gameObject.GetComponent<AudioSource>().PlayOneShot(allDestroy);
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
