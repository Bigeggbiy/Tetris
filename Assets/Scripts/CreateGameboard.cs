using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject squarePrefab; // Reference to the square prefab
    public int columns = 10; // Number of squares per row
    public int rows = 20;    // Number of rows
    public float squareSize = 1f; // Size of each square (assuming 1 unit per square)

    void Start()
    {
        // Create the main parent object called "GameBoard"
        GameObject gameBoard = new GameObject("GameBoard");

        // Loop through each row (starting from the bottom, row 0 is at the bottom)
        for (int row = 1; row <= rows; row++)
        {
            // Create a parent object for the current row
            GameObject rowParent = new GameObject("Row_" + row);
            rowParent.transform.parent = gameBoard.transform; // Set "GameBoard" as its parent

            // Loop through each column within the current row
            for (int col = 1; col <= columns; col++)
            {
                // Instantiate a square prefab at the correct position
                // Since we want the grid to build from the bottom, we'll use row * squareSize for Y position
                GameObject square = Instantiate(squarePrefab, new Vector3(col * squareSize, row * squareSize, 0), Quaternion.identity);

                // Name the square based on its row and column (e.g., "Square_3_5")
                square.name = "Square_" + row + "_" + col;

                // Set the parent of the square to be the current row's parent object
                square.transform.parent = rowParent.transform;
            }
        }
    }
}
