using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStopButton : MonoBehaviour
{
    private bool stop;
    public GameObject Menu1;

    // Update is called once per frame
    void Update()
    {
        if (Menu1.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

   
}
