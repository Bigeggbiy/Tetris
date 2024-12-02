using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int CalculateScore(int lines, int level, int combo)
    {
        int initalValue = 100;
        int score = 0;
        level += 1;

        if (lines == 1) 
        {
            score += initalValue * level;
        }
        else if (lines == 2)
        {
            score += initalValue * 3 * level;
        }
        else if (lines == 3)
        {
            score += initalValue * 5 * level;
        }
        else if (lines == 4)
        {
            score += initalValue * 8 * level;
        }

        if (combo > 0) 
        {
            score += 50 * combo * level;
        }

        return score;

    }
}
