using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTetromino : MonoBehaviour
{
    [SerializeField] string lockedTetrominoTag = "Tetromino";
    [SerializeField] int lockedTetrominoLayer = 7;
    public void SetCorrectAttributes()
    {
        
        gameObject.tag = lockedTetrominoTag;   // Assigns "Tetromino" tag to the main object.
        gameObject.layer = lockedTetrominoLayer; // Assigns a specific layer to the main object.

        // Iterate through all child objects of this object.
        foreach (Transform child in transform)
        {
            // Assign the same tag and layer to each child object.
            child.gameObject.tag = lockedTetrominoTag;   // Ensures the child object has the same tag as the parent.
            child.gameObject.layer = lockedTetrominoLayer; // Ensures the child object is on the same layer as the parent.
        }

        // Disable the UserControls component on the main game object.
        // This prevents the user from further interacting with the tetromino.
        GetComponent<UserControls>().enabled = false;

        // Disable the TetrominoController component on the main game object.
        // This stops the tetromino from being controlled programmatically after locking.
        GetComponent<TetrominoController>().enabled = false;
    }

}
