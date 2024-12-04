using System.Collections.Generic;
using UnityEngine;

public class lineClear : MonoBehaviour
{
    public string targetTag = "Tetromino"; // The tag used for stationary tetromino pieces
    public float detectionRadius = 0.5f;  // Radius for overlap detection
    public int columns = 10;              // Number of columns in the game board


    public int CheckAndClearFilledRows()
    {
        int rowsCleared = 0; // Keeps track of the number of rows cleared in this operation
        List<Transform> rowsToClear = new List<Transform>(); // Stores rows that are fully filled and need to be cleared
        List<Transform> rowsAbove = new List<Transform>(); // Stores rows above the cleared rows for shifting down

        // Loop through each row of the game board
        foreach (Transform row in transform)
        {
            int filledCells = 0; // Count of filled cells in the current row
            Debug.Log(row.name); // Debug log to track the row being processed

            // Loop through each cell in the row
            foreach (Transform cell in row)
            {
                // Check if this cell contains a tetromino
                Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(cell.position, detectionRadius);

                foreach (Collider2D collider in overlappingColliders)
                {
                    // Check if the collider matches the target tag (indicating a filled cell)
                    if (collider.CompareTag(targetTag))
                    {
                        filledCells++; // Increment the filled cell count
                        break; // Exit loop since we only need to confirm one valid collider per cell
                    }
                }
            }

            // If the row is fully filled, mark it for clearing
            if (filledCells >= columns)
            {
                rowsToClear.Add(row); // Add the filled row to the list of rows to clear
            }
            // If rows are marked for clearing, any remaining rows above them are tracked for shifting
            else if (rowsToClear.Count > 0)
            {
                rowsAbove.Add(row); // Add this row to the list of rows above cleared rows
            }
        }

        // Clear the filled rows
        foreach (Transform row in rowsToClear)
        {
            ClearRow(row); // Call the ClearRow method to remove blocks in the filled row
        }

        // If rows were cleared, handle shifting rows above down
        if (rowsToClear.Count > 0)
        {
            // Move rows above the cleared rows downward
            foreach (Transform rows in rowsAbove)
            {
                ShiftRowsDown(rows, rowsToClear.Count); 
            }

            rowsCleared = rowsToClear.Count;
            rowsToClear.Clear();
            rowsAbove.Clear(); 
        }
        else
        {
            rowsCleared = 0; // Reset cleared row count if no rows were cleared
        }

        return rowsCleared; 
    }

    void ClearRow(Transform row)
    {
        // Destroy all blocks in the specified row
        foreach (Transform cell in row)
        {
            Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(cell.position, detectionRadius);

            foreach (Collider2D collider in overlappingColliders)
            {
                // Destroy blocks that match the target tag
                if (collider.CompareTag(targetTag))
                {
                    Destroy(collider.gameObject); // Remove the block from the game
                }
            }
        }
    }

    void ShiftRowsDown(Transform row, int distanceDown)
    {
        // Move all blocks in the specified row downward
        foreach (Transform cell in row)
        {
            Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(cell.position, detectionRadius);

            foreach (Collider2D collider in overlappingColliders)
            {
                // Move blocks that match the target tag
                if (collider.CompareTag(targetTag))
                {
                    collider.transform.position += Vector3.down * distanceDown; // Adjust the position downward
                }
            }
        }
    }
}