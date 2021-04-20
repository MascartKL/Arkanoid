using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLineBlocks : MonoBehaviour
{
    public GameObject gameObject;
    private List<Lines> lines = new List<Lines>();
    private byte maxLines = 3;
    private bool check = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(CheckLine())
		{
            Lines line = new Lines((byte)Random.Range(3, 6), (float)Screen.height / 240 - lines.Count*0.2f, gameObject);
            lines.Add(line);
            lines[lines.Count - 1].CreateLinesBlock();
        }
        removeLine();
    }

    private bool CheckLine()
    {
        if (lines.Count == maxLines)
        {
            return false;
        } 

        return true;
	}

    private void removeLine()
	{
        if (!CheckLine())
        {
            if (lines[maxLines - 1].countBlocks <= 0)
            {
                Debug.Log("Удаление");
                lines.Remove(lines[maxLines - 1]);
            }
        }
    }
}
