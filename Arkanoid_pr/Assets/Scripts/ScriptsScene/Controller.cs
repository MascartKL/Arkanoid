using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public GameObject MenuInGame;
	public GameObject MenuSetting;
	private bool change = false;
	public Button btn;
	public Sprite sp1;
	public Sprite sp2;

	public void Exit()
	{
		SceneManager.LoadScene(1);
		Time.timeScale = 1;
	}

	public void Restart()
	{
		Move.countHit = 0;
		CreateLineBlocks.lines.Clear();
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
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
}
