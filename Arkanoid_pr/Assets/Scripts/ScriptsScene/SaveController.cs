using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveController : MonoBehaviour
{
    public static SaveController instance = null;
    int sceneindex;
    int levelComplete;
    public GameObject LevelComplete;

    public GameObject[] InlevelStars = new GameObject[3];

    void Start()
    {
        if (instance == null)
            instance = this;
        sceneindex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void isEndGame()
    {
        if(sceneindex == 6)
        {
            Invoke("LoadMainMenu", 1f);
        }
        else
        {
            if (levelComplete < sceneindex)
                PlayerPrefs.SetInt("LevelComplete", sceneindex);
            //Invoke("NextLevel", 1f);

            LevelCompl();

            ScoreSave.SaveScore();
            Debug.Log("ok");
            LevelComplete.SetActive(true);
            Time.timeScale = 0;

            
            

            //Invoke("NullScore", 1f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(sceneindex + 1);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void NullScore()
    {
        Score.score = 0;
    }

    public void LevelCompl()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Score.score > 14)        
                InlevelStars[2].SetActive(true);
            else if (Score.score > 7)
                InlevelStars[1].SetActive(true);
            else if (Score.score > 1)
                InlevelStars[0].SetActive(true);
        }

        if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (Score.score > 23)
                InlevelStars[2].SetActive(true);
            else if (Score.score > 16)
                InlevelStars[1].SetActive(true);
            else if (Score.score > 8)
                InlevelStars[0].SetActive(true);
        }

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            if (Score.score > 55)
                InlevelStars[2].SetActive(true);
            else if (Score.score > 35)
                InlevelStars[1].SetActive(true);
            else if (Score.score > 15)
                InlevelStars[0].SetActive(true);
        }
    }
}
