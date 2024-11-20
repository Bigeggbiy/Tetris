using System.Collections.Generic;
using UnityEngine;

public class lineClear : MonoBehaviour
{
    public string targetTag = "Tetromino"; // The tag used for stationary tetromino pieces
    public float detectionRadius = 0.5f;  // Radius for overlap detection
    public int columns = 10;              // Number of columns in the game board

    // Update is called once per frame
    void Update()
    {
        CheckAndClearFilledRows();
    }

    void CheckAndClearFilledRows()
    {
        List<Transform> rowsToClear = new List<Transform>();
        List<Transform> rowsAbove = new List<Transform>();

        // Loop through each row of the game board
        foreach (Transform row in transform)
        {
            int filledCells = 0;

            // Loop through each cell in the row
            foreach (Transform cell in row)
            {
                // Check if this cell contains a tetromino
                Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(cell.position, detectionRadius);

                foreach (Collider2D collider in overlappingColliders)
                {
                    if (collider.CompareTag(targetTag))
                    {
                        filledCells++;
                        break; // No need to check further for this cell
                    }
                }
            }

            // If all columns in the row are filled, mark it for clearing
            if (filledCells >= columns)
            {
                rowsToClear.Add(row);
            }
            // If any row or rows are marked for clearing, begin adding all the remaining rows to ensure the blocks are shifted downward.
            else if (rowsToClear.Count > 0)
            {
                rowsAbove.Add(row);
            }
        }

        // Clear the filled rows
        foreach (Transform row in rowsToClear)
        {
            ClearRow(row);
        }

        // Check if a row has been cleared
        if (rowsToClear.Count > 0)
        {
            // Iterate through all the rows above and move the blocks down
            foreach (Transform rows in rowsAbove)
            {
                ShiftRowsDown(rows, rowsToClear.Count);
            }

            rowsToClear.Clear();
            rowsAbove.Clear();
        }
    }

    void ClearRow(Transform row)
    {
        // Destroy all blocks in the row
        foreach (Transform cell in row)
        {
            Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(cell.position, detectionRadius);

            foreach (Collider2D collider in overlappingColliders)
            {
                if (collider.CompareTag(targetTag))
                {
                    Destroy(collider.gameObject);
                }
            }
        }
    }
    void ShiftRowsDown(Transform row, int distanceDown)
    {
        // Move all blocks down
        foreach (Transform cell in row)
        {
            Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(cell.position, detectionRadius);

            foreach (Collider2D collider in overlappingColliders)
            {
                if (collider.CompareTag(targetTag))
                {
                    collider.transform.position += Vector3.down * distanceDown;
                }
            }
        }
    }


    //void ShiftRowsDown(Transform clearedRow)
    //{
    //    int clearedRowIndex = clearedRow.GetSiblingIndex();

    //    // Loop through rows above the cleared row
    //    for (int rowIndex = clearedRowIndex - 1; rowIndex >= 0; rowIndex--)
    //    {
    //        Transform aboveRow = transform.GetChild(rowIndex);
    //        Transform targetRow = transform.GetChild(rowIndex + 1);

    //        foreach (Transform cell in aboveRow)
    //        {
    //            Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(cell.position, detectionRadius);

    //            foreach (Collider2D collider in overlappingColliders)
    //            {
    //                if (collider.CompareTag(targetTag))
    //                {
    //                    Transform block = collider.transform;

    //                    // Move block down
    //                    block.position += Vector3.down;

    //                    // Update parent to the target cell
    //                    Transform newCell = targetRow.GetChild(cell.GetSiblingIndex());
    //                    block.SetParent(newCell);
    //                    block.localPosition = Vector3.zero; // Align block in new cell
    //                }
    //            }
    //        }
    //    }
    //}
}