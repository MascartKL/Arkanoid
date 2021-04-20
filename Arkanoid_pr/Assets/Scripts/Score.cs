using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    static public int score = 0;
    public GameObject ScoreText;

    void Update()
    {
        ScoreText.GetComponent<Text>().text = "Score: " + score.ToString();  
    }
}
