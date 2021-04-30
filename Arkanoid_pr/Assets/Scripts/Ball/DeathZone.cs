using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameObject Lose;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Destroy(collision.gameObject);
            Lose.SetActive(true);
            Time.timeScale = 0;
        }
        if(collision.gameObject.tag == "Bonus")
		{
            Destroy(collision.gameObject);
        }
    }
}
