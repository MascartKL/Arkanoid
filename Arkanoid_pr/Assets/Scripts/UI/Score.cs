using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    static public int score = 10;
    public GameObject ScoreText;
    private double tmpscore = 0;

    private void Start()
    {
        score = 0;
    }

    void Update()
    {
        if ((tmpscore == 1 || tmpscore > 1) && score > 1)
        {
            score = score - 1;
            tmpscore = tmpscore - 1;
        }
        ScoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }
    private void FixedUpdate()
    {
        tmpscore += 0.003;
        
    }
}
