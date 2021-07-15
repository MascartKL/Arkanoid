using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    public int[] scores = new int[5];

    public GameObject[] ScoreText = new GameObject[5];

    public GameObject InfScore;


    public GameObject[] levelStars = new GameObject[15];

    private void Start()
    {
        UpdateScore();

        for (int i = 0; i < 5; i++)
        {
            ScoreText[i].GetComponent<Text>().text = "Score: " + scores[i].ToString();
        }

        InfScore.GetComponent<Text>().text = "Best score: " + PlayerPrefs.GetInt("InfLevelScore").ToString();
    }

    public void UpdateScore()
    {

            scores[0] = PlayerPrefs.GetInt("1LevelScore");

            scores[1] = PlayerPrefs.GetInt("2LevelScore");

            scores[2] = PlayerPrefs.GetInt("3LevelScore");

            scores[3] = PlayerPrefs.GetInt("4LevelScore");

            scores[4] = PlayerPrefs.GetInt("5LevelScore");

        if (scores[0] > 14)
            levelStars[2].SetActive(true);
        else if (scores[0] > 7)
            levelStars[1].SetActive(true);
        else if(scores[0] > 1)
            levelStars[0].SetActive(true);

        if (scores[1] > 14)
            levelStars[5].SetActive(true);
        else if (scores[1] > 7)
            levelStars[4].SetActive(true);
        else if (scores[1] > 1)
            levelStars[3].SetActive(true);

        if (scores[2] > 23)
            levelStars[8].SetActive(true);
        else if (scores[2] > 16)
            levelStars[7].SetActive(true);
        else if (scores[2] > 8)
            levelStars[6].SetActive(true);

        if (scores[3] > 23)
            levelStars[11].SetActive(true);
        else if (scores[3] > 16)
            levelStars[10].SetActive(true);
        else if (scores[3] > 8)
            levelStars[9].SetActive(true);

        if (scores[4] > 55)
            levelStars[14].SetActive(true);
        else if (scores[4] > 35)
            levelStars[13].SetActive(true);
        else if (scores[4] > 15)
            levelStars[12].SetActive(true);
    }

}
