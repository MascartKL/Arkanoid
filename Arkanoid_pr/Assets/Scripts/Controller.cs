using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MenuInGame;

	private void Start()
	{
		
	}
	// Update is called once per frame
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
		{
           pause();
		}
    }

	private int pause()
	{
		if (Time.timeScale != 0)
		{
			Time.timeScale = 0;
			MenuInGame.SetActive(true);
			return 0;
		}

		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			MenuInGame.SetActive(false);
			return 0;
		}

		return 0;
	}
}
