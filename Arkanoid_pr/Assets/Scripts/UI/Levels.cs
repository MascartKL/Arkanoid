using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    private List<Button> buttons = new List<Button>();

    void Start()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
		{
           buttons.Add(gameObject.GetComponentsInChildren<Button>()[i]);
		}
    }

    public void LoadScene(Button button)
	{
        SceneManager.LoadScene("Scenes/" + button.name.ToString());
	}
}
