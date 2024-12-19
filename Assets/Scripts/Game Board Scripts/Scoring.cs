using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int CalculateScore(int lines, int level, int combo)
    {
        // Base score value for a single line
        int initialValue = 100;

        // Variable to store the calculated score
        int score = 0;

        // Increment level by 1 to start levels from 1 instead of 0
        level += 1;

        // Calculate score based on the number of lines cleared
        if (lines == 1)
        {
            // Single line cleared, multiply base value by current level
            score += initialValue * level;
        }
        else if (lines == 2)
        {
            // Two lines cleared, apply multiplier and adjust for level
            score += initialValue * 3 * level;
        }
        else if (lines == 3)
        {
            // Three lines cleared, higher multiplier for increased difficulty
            score += initialValue * 5 * level;
        }
        else if (lines == 4)
        {
            // Four lines cleared (likely a Tetris), highest multiplier for maximum reward
            score += initialValue * 8 * level;
        }

        // Bonus score calculation for combos
        if (combo > 0)
        {
            // Add bonus points for combos, scaled by combo streak and level
            score += 50 * combo * level;
        }

        // Return the total calculated score
        return score;
    }

}
