using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject MenuInGame;
	public GameObject MenuSetting;
    public GameObject MenuLevel;
	private bool change = false;
	public Button btn;
	public Sprite sp1;
	public Sprite sp2;

    public void Exit()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
	}

	public void Restart()
	{
		Move.countHit = 0;
        Time.timeScale = 1;
        Score.score = 0;

        if(SceneManager.GetActiveScene().buildIndex == 1)
            CreateLineBlocks.lines.Clear();
		
        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(3);
                break;
            case 4:
                SceneManager.LoadScene(4);
                break;
            case 5:
                SceneManager.LoadScene(5);
                break;
            case 6:
                SceneManager.LoadScene(6);
                break;
        }
	}

	public  void  pause()
	{
		if (Time.timeScale != 0)
		{
			Time.timeScale = 0;
			MenuInGame.SetActive(true);
			return;
		}

		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			MenuInGame.SetActive(false);
			MenuSetting.SetActive(false);
			return;
		}
	}

	public void settingsBtns()
	{
		
			MenuInGame.SetActive(false);
			MenuSetting.SetActive(true);
		
	}

	public void btnSoundPressed()
	{
		if(!change)
		{
			btn.image.sprite = sp1;
			AudioListener.volume = 0;
			change = true;
		}
		else
		{
			btn.image.sprite = sp2;
			AudioListener.volume = 1;
			change = false;
		}
	}

    public void ChLevel()
    {
        MenuInGame.SetActive(false);
        MenuLevel.SetActive(true);
    }
    public void BackLMtoMenu()
    {
        MenuInGame.SetActive(true);
        MenuLevel.SetActive(false);
    }
    public void BackSetToMenu()
    {
        MenuInGame.SetActive(true);
        MenuSetting.SetActive(false);
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Score.score = 0;

        }
    }
}
