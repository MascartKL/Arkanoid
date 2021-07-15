using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSave : MonoBehaviour
{
    public static void SaveScore()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                if (Score.score > PlayerPrefs.GetInt("1LevelScore"))
                    PlayerPrefs.SetInt("1LevelScore", Score.score);
                break;
            case 3:
                if (Score.score > PlayerPrefs.GetInt("2LevelScore"))
                    PlayerPrefs.SetInt("2LevelScore", Score.score);
                break;
            case 4:
                if (Score.score > PlayerPrefs.GetInt("3LevelScore"))
                    PlayerPrefs.SetInt("3LevelScore", Score.score);
                break;
            case 5:
                if (Score.score > PlayerPrefs.GetInt("4LevelScore"))
                    PlayerPrefs.SetInt("4LevelScore", Score.score);
                break;
            case 6:
                if (Score.score > PlayerPrefs.GetInt("5LevelScore"))
                    PlayerPrefs.SetInt("5LevelScore", Score.score);
                break;
        }
    }

    public static void InfSaveScore()
    {
        if (Score.score > PlayerPrefs.GetInt("InfLevelScore"))
            PlayerPrefs.SetInt("InfLevelScore", Score.score);
    }
}
