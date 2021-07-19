using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    public int[] scores = new int[5];

    public GameObject[] ScoreText = new GameObject[5];

    public GameObject InfScore;

    public GameObject StarNumberText;

    public static int starnumb = 0;

    public Button BuyButBall2;
    public Button BuyButBall3;
    public static bool isBuyBall2 = false;
    public static bool isBuyBall3 = false;
    public Button invBall1;
    public Button invBall2;
    public Button invBall3;


    public GameObject LowStarIm;

    static public int numBallCh;

    public GameObject[] levelStars = new GameObject[15];

    private AudioClip soundBuy, soundAmogus, football, ball1_s;

    static public int numUpDamage = 0;
    static public int damageUpcost = 10;
    public GameObject costUpDamageText;

    public Button control1;
    public Button control2;

    static public int chcontrol = 1;

    private void Awake()
    {
        soundBuy = Resources.Load("SBuy") as AudioClip;
        soundAmogus = Resources.Load("Амогус") as AudioClip;
        football = Resources.Load("football_sound") as AudioClip;
        ball1_s = Resources.Load("ball1_sound") as AudioClip;
    }
    private void Start()
    {
        starnumb = 30;

        if (numBallCh == null)
            numBallCh = 1;

        if (PlayerPrefs.GetInt("chcontrol") == 0)
            PlayerPrefs.SetInt("chcontrol", 1);

        UpdateScore();

        for (int i = 0; i < 5; i++)
        {
            ScoreText[i].GetComponent<Text>().text = "Score: " + scores[i].ToString();
        }

        InfScore.GetComponent<Text>().text = "Best score: " + PlayerPrefs.GetInt("InfLevelScore").ToString();

        StarNumberText.GetComponent<Text>().text = starnumb.ToString();

        if(PlayerPrefs.GetInt("isBuyBall2") == 1)
        {
            invBall2.interactable = true;
            BuyButBall2.interactable = false;
        }
        else
        {
            invBall2.interactable = false;
            BuyButBall2.interactable = true;
        }

        if (PlayerPrefs.GetInt("isBuyBall3") == 1)
        {
            invBall3.interactable = true;
            BuyButBall3.interactable = false;
        }
        else
        {
            invBall3.interactable = false;
            BuyButBall3.interactable = true;
        }


        if (PlayerPrefs.GetInt("upDamageCost") != 0)
            damageUpcost = PlayerPrefs.GetInt("upDamageCost");
        else
            damageUpcost = 10;

        costUpDamageText.GetComponent<Text>().text = "X" + damageUpcost.ToString();

        switch(PlayerPrefs.GetInt("chcontrol"))
        {
            case 1:
                {
                    control1.interactable = false;
                    break;
                }
            case 2:
                {
                    control2.interactable = false;
                    break;
                }
        }
    }

    public void BuyBall2()
    {
        if (starnumb >= 2)
        {
            starnumb -= 2;
            StarNumberText.GetComponent<Text>().text = starnumb.ToString();
            BuyButBall2.interactable = false;
            isBuyBall2 = true;
            
            PlayerPrefs.SetInt("isBuyBall2", 1);
            isBuy2();
            gameObject.GetComponent<AudioSource>().PlayOneShot(soundBuy);
        }
        else
        {
            LowStarIm.SetActive(true);
            Invoke("LowStarOff", 1f);
        }      
    }

    public void BuyBall3()
    {
        if (starnumb >= 3)
        {
            starnumb -= 3;
            StarNumberText.GetComponent<Text>().text = starnumb.ToString();
            BuyButBall3.interactable = false;
            isBuyBall3 = true;
            
            PlayerPrefs.SetInt("isBuyBall3", 1);
            isBuy3();
            gameObject.GetComponent<AudioSource>().PlayOneShot(soundBuy);
        }
        else
        {
            LowStarIm.SetActive(true);
            Invoke("LowStarOff", 1f);
        }
    }

    public void isBuy2()
    {
        if (PlayerPrefs.GetInt("isBuyBall2") == 1)
            invBall2.interactable = true;
        else
            invBall2.interactable = false;
    }

    public void isBuy3()
    {
        if (PlayerPrefs.GetInt("isBuyBall3") == 1)
            invBall3.interactable = true;
        else
            invBall3.interactable = false;
    }

    public void LowStarOff()
    {
        LowStarIm.SetActive(false);
    }

    public void InvBall1B()
    {
        numBallCh = 1;
        gameObject.GetComponent<AudioSource>().PlayOneShot(ball1_s);
        invBall1.interactable = false;
        invBall2.interactable = true;
        invBall3.interactable = true;
    }
    public void InvBall2B()
    {
        numBallCh = 2;
        gameObject.GetComponent<AudioSource>().PlayOneShot(football);
        invBall1.interactable = true;
        invBall2.interactable = false;
        invBall3.interactable = true;
    }
    public void InvBall3B()
    {
        numBallCh = 3;
        gameObject.GetComponent<AudioSource>().PlayOneShot(soundAmogus);
        invBall1.interactable = true;
        invBall2.interactable = true;
        invBall3.interactable = false;
    }
    public void upDamage()
    {
        if (starnumb >= damageUpcost)
        {
            numUpDamage += 1;
            PlayerPrefs.SetInt("upDamage", numUpDamage);
            numUpDamage = PlayerPrefs.GetInt("upDamage");
            starnumb -= damageUpcost;
            PlayerPrefs.SetInt("upDamageCost", damageUpcost + 5);
            damageUpcost = PlayerPrefs.GetInt("upDamageCost");

            StarNumberText.GetComponent<Text>().text = starnumb.ToString();
            costUpDamageText.GetComponent<Text>().text = "X" + damageUpcost.ToString();
        }
        else
        {
            LowStarIm.SetActive(true);
            Invoke("LowStarOff", 1f);
        }
    }
    public void Control1B()
    {
        control1.interactable = false;
        control2.interactable = true;
        PlayerPrefs.SetInt("chcontrol", 1);
    }
    public void Control2B()
    {
        control1.interactable = true;
        control2.interactable = false;
        PlayerPrefs.SetInt("chcontrol", 2);
    }

    public void UpdateScore()
    {

            scores[0] = PlayerPrefs.GetInt("1LevelScore");

            scores[1] = PlayerPrefs.GetInt("2LevelScore");

            scores[2] = PlayerPrefs.GetInt("3LevelScore");

            scores[3] = PlayerPrefs.GetInt("4LevelScore");

            scores[4] = PlayerPrefs.GetInt("5LevelScore");

        if (scores[0] > 14)
        {
            levelStars[2].SetActive(true);
            starnumb += 3;
        }
        else if (scores[0] > 7)
        {
            levelStars[1].SetActive(true);
            starnumb += 2;
        }
        else if (scores[0] > 1)
        {
            levelStars[0].SetActive(true);
            starnumb += 1;
        }

        if (scores[1] > 14)
        {
            levelStars[5].SetActive(true);
            starnumb += 3;
        }
        else if (scores[1] > 7)
        {
            levelStars[4].SetActive(true);
            starnumb += 2;
        }
        else if (scores[1] > 1)
        {
            levelStars[3].SetActive(true);
            starnumb += 1;
        }

        if (scores[2] > 23)
        {
            levelStars[8].SetActive(true);
            starnumb += 3;
        }
        else if (scores[2] > 16)
        {
            levelStars[7].SetActive(true);
            starnumb += 2;
        }
        else if (scores[2] > 8)
        {
            levelStars[6].SetActive(true);
            starnumb += 1;
        }

        if (scores[3] > 23)
        {
            levelStars[11].SetActive(true);
            starnumb += 3;
        }
        else if (scores[3] > 16)
        {
            levelStars[10].SetActive(true);
            starnumb += 2;
        }
        else if (scores[3] > 8)
        {
            levelStars[9].SetActive(true);
            starnumb += 1;
        }

        if (scores[4] > 55)
        {
            levelStars[14].SetActive(true);
            starnumb += 3;
        }
        else if (scores[4] > 35)
        {
            levelStars[13].SetActive(true);
            starnumb += 2;
        }
        else if (scores[4] > 15)
        {
            levelStars[12].SetActive(true);
            starnumb += 1;
        }

        if (PlayerPrefs.GetInt("isBuyBall2") == 1)
            starnumb -= 2;
        if (PlayerPrefs.GetInt("isBuyBall3") == 1)
            starnumb -= 3;
    }

}
