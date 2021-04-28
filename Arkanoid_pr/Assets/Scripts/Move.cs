using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.5f;
    public PressedButton leftButton;
    public PressedButton rightButton;
    private Vector3 default_scale;
    private GameObject ball;

	private void Awake()
	{
        ball = GameObject.Find("Ball");
        default_scale = gameObject.transform.localScale;
	}

	void Update()
    {
        if (leftButton.isPressed  && transform.position.x > -1.8f + gameObject.transform.localScale.x / 2 )
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (rightButton.isPressed  && transform.position.x < 1.8f - gameObject.transform.localScale.x / 2)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.name == "BonusLenght(Clone)" && gameObject.transform.localScale == default_scale)
        {
            gameObject.transform.localScale += new Vector3(0.5f, 0, 0);
            Destroy(collision.gameObject);
            sourceStateLenght();
        }
        if(collision.gameObject.name == "BonusDamage(Clone)")
		{
            MoveBall.damageBall++;
            Destroy(collision.gameObject);
            ball.GetComponent<SpriteRenderer>().color = Color.cyan;
            sourceStateDamage();
        }
    }

    private async void  sourceStateLenght()
	{
        await Task.Delay(5000);
        gameObject.transform.localScale = default_scale;
    }
    private async void sourceStateDamage()
    {
        await Task.Delay(10000);
        ball.GetComponent<SpriteRenderer>().color = Color.white;
        MoveBall.damageBall--;
    }
}
