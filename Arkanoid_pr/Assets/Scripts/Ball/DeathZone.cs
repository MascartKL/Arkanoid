using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameObject Lose;
    private AudioClip soundLose;

    private void Awake()
    {
        soundLose = Resources.Load("SGameOver") as AudioClip;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Destroy(collision.gameObject);
            Lose.SetActive(true);
            Time.timeScale = 0;
            ScoreSave.InfSaveScore();
            gameObject.GetComponent<AudioSource>().PlayOneShot(soundLose);
        }
        if (collision.gameObject.tag == "BonusDamage" || collision.gameObject.tag == "BonusLenght" || collision.gameObject.tag == "BonusScore")
        {
            Destroy(collision.gameObject);
        }
    }
}
