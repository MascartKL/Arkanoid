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
    private AudioClip bonusLenght, bonusDamage;

    public static int countHit = 0;

    static public bool isBonusScore = false;

    private Rigidbody2D _rigibody2d;

    private float _moveX = 0f;
    private float _speed = 7f;
    private float BorderPositionLeft = -1.5f;
    private float BorderPositionRight = 1.5f;
    private SpriteRenderer BorderSprite;

    private void Awake()
    {
        Time.timeScale = 1;
        bonusDamage = Resources.Load("BallDamage") as AudioClip;
        bonusLenght = Resources.Load("BoardLenght") as AudioClip;

        ball = GameObject.Find("Ball");
        default_scale = gameObject.transform.localScale;

        _rigibody2d = GetComponent<Rigidbody2D>();
        BorderSprite = GetComponent<SpriteRenderer>();
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

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("chcontrol") == 2)
        {
             //if ((transform.position.x >= -1.3f && _moveX > 0 )|| (transform.position.x <= 1.3f && _moveX < 0))
        
            float positionX = _rigibody2d.position.x + _moveX * _speed * Time.fixedDeltaTime;
            positionX = Mathf.Clamp(positionX, BorderPositionLeft + (BorderSprite.size.x / 2), BorderPositionRight - (BorderSprite.size.x / 2));
            _rigibody2d.MovePosition(new Vector2(positionX, _rigibody2d.position.y));
        

           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.name == "BonusLenght(Clone)" && gameObject.transform.localScale == default_scale)
        {
            gameObject.transform.localScale += new Vector3(0.5f, 0, 0);
            gameObject.GetComponent<AudioSource>().PlayOneShot(bonusLenght);
            Destroy(collision.gameObject);
            sourceStateLenght();
        }
        if(collision.gameObject.name == "BonusDamage(Clone)")
		{
            MoveBall.damageBall++;
            gameObject.GetComponent<AudioSource>().PlayOneShot(bonusDamage);
            Destroy(collision.gameObject);
            ball.GetComponent<SpriteRenderer>().color = Color.cyan;
            sourceStateDamage();
        }
        if (collision.gameObject.name == "BonusScore(Clone)")
        {
            Destroy(collision.gameObject);
            isBonusScore = true;
            ball.GetComponent<SpriteRenderer>().color = Color.black;
            sourceStateScore();
        }

    }

	private async void  sourceStateLenght()
	{
        await Task.Delay(5000);
        if(gameObject != null)
		{
            gameObject.transform.localScale = default_scale;
        }
        
    }

    private async void sourceStateDamage()
    {
        await Task.Delay(10000);
        ball.GetComponent<SpriteRenderer>().color = Color.white;
        MoveBall.damageBall--;
    }

    private async void sourceStateScore()
    {
        await Task.Delay(5000);
        ball.GetComponent<SpriteRenderer>().color = Color.white;
        isBonusScore = false;

    }

    private void OnEnable()
    {
        PlayerInput.OnMove += move;
    }

    private void OnDisable()
    {
        PlayerInput.OnMove -= move;
    }

    private void move(float moveX)
    {
        _moveX = moveX;
    }
}
