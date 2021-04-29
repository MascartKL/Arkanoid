using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TextView : MonoBehaviour
{
    
    private  GameObject container;
    private  GameObject canvas;
    private  Text text;

    private string _text;
    private Vector2 position;
    private GameObject tmp;

    public TextView(string _text, Vector2 position)
	{
        container = GameObject.Find("Value");
        canvas = GameObject.Find("Canvas");
        this.position = position*150;
        this._text = _text;
    }


    public void moveText()
	{
        tmp = Instantiate(container,position,Quaternion.identity);
        tmp.transform.SetParent(canvas.transform, false);
        tmp.transform.localPosition = position;

        text = tmp.GetComponent<Text>();
        text.text = "+" + _text;
        animationText();
    }

    private async void animationText()
	{
        for(int i = 0; i < 10; i++)
		{
            await Task.Delay(50);
            text.fontSize+=4;
        }
      
        active();
    }

    private async void  active()
	{
        await Task.Delay(500);
        Destroy(tmp); 
    }
}
