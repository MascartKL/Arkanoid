using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MenuInGame;

	public void Exit()
	{
		SceneManager.LoadScene(1);
		Time.timeScale = 1;
	}

	public void Restart()
	{
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
			return;
		}

		return;
	}
}
