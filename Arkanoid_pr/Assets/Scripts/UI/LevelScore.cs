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
    public Button invBall2;
    public Button invBall3;


    public GameObject LowStarIm;

    static public int numBallCh;


    public GameObject[] levelStars = new GameObject[15];

    private void Start()
    {
        starnumb = 0;

        if (numBallCh == null)
            numBallCh = 1;

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

    }

    public void BuyBall2()
    {
        if (starnumb >= 5)
        {
            starnumb -= 5;
            StarNumberText.GetComponent<Text>().text = starnumb.ToString();
            BuyButBall2.interactable = false;
            isBuyBall2 = true;
            
            PlayerPrefs.SetInt("isBuyBall2", 1);
            isBuy2();
        }
        else
        {
            LowStarIm.SetActive(true);
            Invoke("LowStarOff", 1f);
        }      
    }

    public void BuyBall3()
    {
        if (starnumb >= 7)
        {
            starnumb -= 7;
            StarNumberText.GetComponent<Text>().text = starnumb.ToString();
            BuyButBall3.interactable = false;
            isBuyBall3 = true;
            
            PlayerPrefs.SetInt("isBuyBall3", 1);
            isBuy3();
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
    }
    public void InvBall2B()
    {
        numBallCh = 2;
    }
    public void InvBall3B()
    {
        numBallCh = 3;
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
            starnumb -= 5;
        if (PlayerPrefs.GetInt("isBuyBall3") == 1)
            starnumb -= 7;
    }

}
