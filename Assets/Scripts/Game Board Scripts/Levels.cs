using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public int level = 0;
    private int linesBeforeIncrease = 10;
    public int linesRemaining = 10;

    public int DetermineLevel(int linesCleared)
    {
        linesRemaining -= linesCleared;

        if (linesRemaining <= 0) 
        {
            linesRemaining += linesBeforeIncrease;
            level += 1;
        }

        return level;
    }
}
