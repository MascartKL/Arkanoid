using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrig : MonoBehaviour
{
    //public static int blocks;
    // Start is called before the first frame update
    void Start()
    {
        //blocks = GameObject.FindGameObjectsWithTag("Block").Length - 1;
    }
    private void Update()
    {
       // blocks = GameObject.FindGameObjectsWithTag("Block").Length - 1;
        // test = BlockDestroy.blocks;
      //  if (BlockDestroy.blocks < 15)
       // Debug.Log(BlockDestroy.blocks);
        if (BlockDestroy.blocks <= 10)
            SaveController.instance.isEndGame();
    }
}
