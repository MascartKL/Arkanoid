using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrig : MonoBehaviour
{
    void Start()
    {
        //blocks = GameObject.FindGameObjectsWithTag("Block").Length - 1;
    }
    private void Update()
    {
        if (BlockDestroy.blocks <= 0)
            SaveController.instance.isEndGame();
    }
}
