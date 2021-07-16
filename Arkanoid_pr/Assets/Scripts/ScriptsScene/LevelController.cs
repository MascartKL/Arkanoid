using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public GameObject[] locklevel = new GameObject[5];

    public Button[] btlevel = new Button[6];

    int levelcomplete;

    void Start()
    {
        levelcomplete = PlayerPrefs.GetInt("LevelComplete");

        for(int i = 1;i< 6;i++)
        {
            if (levelcomplete == i)
            {
                btlevel[i].interactable = true;
                locklevel[i].SetActive(false);
            }

        }
        for (int i = 5; i > 0; i--)
        {
            if (btlevel[i].interactable == true)
            {
                btlevel[i - 1].interactable = true;
                locklevel[i - 1].SetActive(false);
            }
        }
    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Reset()
    {
        for (int i = 2; i < 6; i++)
        {
            btlevel[i].interactable = false;
        }
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
