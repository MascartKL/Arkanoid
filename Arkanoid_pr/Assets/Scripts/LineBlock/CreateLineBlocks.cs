using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CreateLineBlocks : MonoBehaviour
 {
    public GameObject block;
    public static List<Lines> lines = new List<Lines>();
    private byte maxLines = 3;
    private byte i = 0;

    void Update()
    {
        if(CheckLine())
		{
            Lines line = new Lines((byte)Random.Range(3, 7), 3.3f - i*0.3f, block);
            lines.Add(line);
            lines[lines.Count - 1].CreateLinesBlock();
            i++;
        }
    }

    private bool CheckLine()
    {
        if (lines.Count < maxLines)
        {
            return true;
        }
        i = 0;
        return false;
	}


    private async static void OffsetLine()
	{
        await Task.Delay(500);
        for(int i = 0; i < lines.Count; i++)
		{
			foreach (var obj in lines[i].gameObjects)
			{
                if(obj != null)
				{
                    obj.transform.position += Vector3.up * -1.0f * lines.Count * 0.1f;
                }
			}
		}
	}

    public static void BlockInLinesRemove(byte numberLine, GameObject block)
	{
        lines[numberLine].gameObjects.Remove(block);
        RemoveLine(numberLine);
    }

    private static void RemoveLine(byte numberLine)
    {
        if (lines[numberLine].gameObjects.Count <= 2)
		{
            lines.Remove(lines[numberLine]);
            OffsetLine();
        }
    }

}
