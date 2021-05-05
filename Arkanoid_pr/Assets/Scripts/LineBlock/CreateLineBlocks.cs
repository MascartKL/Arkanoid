using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CreateLineBlocks : MonoBehaviour
 {
    public GameObject block;
    public static List<Lines> lines = new List<Lines>();
    private static bool createLine = false;
    private byte maxLines = 3;
    private byte i;

	private void Update()
    {
        if(CheckLine())
		{
            CreateLine();
        }
    }

    private  bool CheckLine()
    {
        if (lines.Count < maxLines)
        {
            return true;
        }

        if(createLine)
		{
            createLine = false;
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
                    obj.transform.position = new Vector2(obj.transform.position.x,obj.transform.position.y - 0.3f);
                    obj.GetComponent<BlockDestroy>().numberLine++;
                }
			}
		}
        createLine = true;
    }

    public static void BlockInLinesRemove(byte numberLine, GameObject block)
	{
        lines[numberLine].gameObjects.Remove(block);
        RemoveLine(numberLine);
    }

    private static void RemoveLine(byte numberLine)
    {
        if (lines[numberLine].gameObjects.Count == 0)
        {
           lines.Remove(lines[numberLine]);
        }
    }

    public static void CheckOffset(int count)
	{
        if(count % 10 == 0)
		{
            OffsetLine();
		}
	}

    private void CreateLine()
	{
        Lines line = new Lines((byte)Random.Range(3, 7), 3.3f - i * 0.3f, block);
        i++;
        lines.Add(line);
        lines[lines.Count - 1].CreateLinesBlock();
        Debug.Log(i);
    }

}
