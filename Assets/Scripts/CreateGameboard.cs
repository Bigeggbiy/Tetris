using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameBoard : MonoBehaviour
{
    public GameObject squarePrefab; // Reference to the square prefab
    public int columns = 10; // Number of squares per row
    public int rows = 20;    // Number of rows
    public float squareSize = 1f; // Size of each square (assuming 1 unit per square)

    void Start()
    {
        // Create the main parent object called "GameBoard"
        GameObject gameBoard = new GameObject("GameBoard");

        // Calculate the offsets to center the board, the position (-5,-10.5,0) seems to fit perfectly
        // if the scene size = 10, this just moves half a board width to the left, and half a board 
        // height down
        float xOffset = (columns * squareSize) / 2f;
        float yOffset = (rows * squareSize) / 2f;

        // Loop through each row (starting from the bottom, row 0 is at the bottom)
        for (int row = 1; row <= rows; row++)
        {
            // Create a parent object for the current row
            GameObject rowParent = new GameObject("Row_" + row);
            rowParent.transform.parent = gameBoard.transform; // Set "GameBoard" as its parent

            // Loop through each column within the current row
            for (int col = 1; col <= columns; col++)
            {
                // Instantiate a square prefab at the correct position, with offsets applied
                // Since we want the grid to build from the bottom, we'll use row * squareSize for Y position
                float xPos = (col * squareSize) - xOffset;
                float yPos = (row * squareSize) - yOffset;

                GameObject square = Instantiate(squarePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);

                // Name the square based on its row and column (e.g., "Square_3_5")
                square.name = "Square_" + row + "_" + col;

                // Set the parent of the square to be the current row's parent object
                square.transform.parent = rowParent.transform;
            }
        }

        // Center the gameboard itself at (-5,-10.5,0), this lowers the board by .5, which fits screen
        // size = 10 perfectly for some reason
        gameBoard.transform.position = new Vector3(0, -0.5f, 0);
    }
}
