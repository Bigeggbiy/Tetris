using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{
    private CreateGameBoard topRowScript;
    private List<Transform> topRowTransforms;
    private string targetTag = "Tetromino";

    void Start()
    {
        // Initialize the script for creating the game board by getting the associated component.
        topRowScript = GetComponent<CreateGameBoard>();

        // Retrieve the array of transforms representing the top row squares of the game board.
        topRowTransforms = topRowScript.topRowSquares;
    }

    public bool CheckTopRow()
    {
        // Iterate through each cell (Transform) in the top row.
        foreach (Transform cell in topRowTransforms)
        {
            // Check if there are any colliders overlapping with this cell 
            Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(cell.position, 0.5f);

            // Iterate through all colliders found in the detection area.
            foreach (Collider2D collider in overlappingColliders)
            {
                // Check if the collider's tag matches a tetromino block.
                if (collider.CompareTag(targetTag))
                {
                    // If a matching tag is found, return true indicating the top row contains a block.
                    return true;
                }
            }
        }

        // If no matching colliders are found in the top row, return false.
        return false;
    }

}
