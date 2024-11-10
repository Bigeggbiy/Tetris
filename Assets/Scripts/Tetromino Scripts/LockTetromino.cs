using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTetromino : MonoBehaviour
{
    [SerializeField] string lockedTetrominoTag = "Tetromino";
    [SerializeField] int lockedTetrominoLayer = 7;
    public void SetCorrectAttributes()
    {
        // Set the tag and layer of the main object
        gameObject.tag = lockedTetrominoTag;
        gameObject.layer = lockedTetrominoLayer;

        // Set the tag and layer of all children recursively
        foreach (Transform child in transform)
        {
            child.gameObject.tag = lockedTetrominoTag;
            child.gameObject.layer = lockedTetrominoLayer;
        }

        GetComponent<UserControls>().enabled = false;
        GetComponent<TetrominoController>().enabled = false;
    }
}
