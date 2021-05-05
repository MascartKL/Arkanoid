using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{  
    public void Play()
    {
        Move.countHit = 0;
        CreateLineBlocks.lines.Clear();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }



    public void Quite()
    {
        Application.Quit();
    }
}
