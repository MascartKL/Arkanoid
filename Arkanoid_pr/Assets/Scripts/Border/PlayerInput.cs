using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{

    public static event Action<float> OnMove;
    private Vector2 _startposition = Vector2.zero;
    private float _direction = 0f;


    private void GetTouchInput()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
               // case TouchPhase.Began:
               //     break;
                case TouchPhase.Moved:
                    // _direction = touch.position.x > _startposition.x ? 1f : -1f;
                    if (touch.position.x > _startposition.x + 15)
                    {
                        _direction = 1f;
                    }
                    if (touch.position.x < _startposition.x - 15)
                    {
                        _direction = -1f;
                    }
                        break;
                /* case TouchPhase.Stationary:
                     break;
                 case TouchPhase.Ended:
                     break;
                 case TouchPhase.Canceled:
                     break;*/
                default:
                    _startposition = touch.position;
                    _direction = 0f;
                    break;
            }
            OnMove?.Invoke(_direction);
        }
    }

    // Update is called once per frame
    void Update()
    {

        GetTouchInput();

    }
}
