using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InLevelComplete : MonoBehaviour
{
    public GameObject[] InlevelStars = new GameObject[3];
    // Start is called before the first frame update


    public void LevelCompl()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Score.score > 14)
                 InlevelStars[2].SetActive(true);
            else if (Score.score > 7)
                 InlevelStars[1].SetActive(true);
            else if (Score.score > 1)
                 InlevelStars[0].SetActive(true);
        }
    }

}
