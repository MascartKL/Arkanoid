using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
   /* public Button blevel2;
    public Button blevel3;
    public Button blevel4;
    public Button blevel5;
    */
    public GameObject[] locklevel = new GameObject[5];

    public Button[] btlevel = new Button[6];

    int levelcomplete;

    void Start()
    {
        levelcomplete = PlayerPrefs.GetInt("LevelComplete");
        //blevel2.interactable = false;
        //blevel3.interactable = false;

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

        /*switch (levelcomplete)
        {
            case 2:
                blevel2.interactable = true;
                //locklevel[]
                break;
            case 3:
              //  blevel2.interactable = true;
                blevel3.interactable = true;
                break;
            case 4:
                //blevel2.interactable = true;
               // blevel3.interactable = true;
                blevel4.interactable = true;
                break;
            case 5:
               // blevel2.interactable = true;
               // blevel3.interactable = true;
               // blevel4.interactable = true;
                blevel5.interactable = true;
                break;
            case 6:
                //blevel2.interactable = true;
                //blevel3.interactable = true;
                //blevel4.interactable = true;
               // blevel5.interactable = true;
                blevel5.interactable = true;
                break;
        }*/
    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Reset()
    {
       // blevel2.interactable = false;
       // blevel3.interactable = false;
       // blevel4.interactable = false;
       // blevel5.interactable = false;

        for (int i = 2; i < 6; i++)
        {
            btlevel[i].interactable = false;
        }
            PlayerPrefs.DeleteAll();
;
    }
}
