using System.Collections.Generic;
using UnityEngine;

// Class responsible for creating and managing the game board
public class CreateGameBoard : MonoBehaviour
{
    public GameObject squarePrefab; // Reference to the prefab for creating individual squares
    public int columns = 10; // Number of squares in each row
    public int rows = 20;    // Total number of rows in the game board
    public float squareSize = 1f; // Size of each square (width and height)
    public float redRate = 0f; // Initial red color intensity for the square outlines
    public float greenRate = 0f; // Initial green color intensity for the square outlines
    public float blueRate = 0f; // Initial blue color intensity for the square outlines

    public List<Transform> topRowSquares = new List<Transform>();  // List to store transforms of squares in the top row

    void Awake()
    {
        // Automatically create the game board when the script is loaded
        CreateBoard();
    }

    // Method to create the game board with squares arranged in rows and columns
    private void CreateBoard()
    {
        // Create a parent object for the entire game board
        GameObject gameBoard = new GameObject("GameBoard");
        gameBoard.tag = "Game Board"; // Assign a tag for easy identification
        gameBoard.AddComponent<IsFilled>(); // Attach a script to check if squares are filled
        gameBoard.AddComponent<lineClear>(); // Attach a script to handle line-clearing logic

        // Calculate offsets to center the game board in the scene
        float xOffset = (columns * squareSize) / 2f;
        float yOffset = (rows * squareSize) / 2f;

        // Loop through each row
        for (int row = 1; row <= rows; row++)
        {
            // Create a parent object for each row
            GameObject rowParent = new GameObject("Row_" + row);
            rowParent.transform.parent = gameBoard.transform; // Set the row's parent as the game board

            // Loop through each column within the current row
            for (int col = 1; col <= columns; col++)
            {
                // Calculate the position for each square
                float xPos = (col * squareSize) - xOffset;
                float yPos = (row * squareSize) - yOffset + 1;

                // Instantiate a square prefab at the calculated position
                GameObject square = Instantiate(squarePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
                square.name = "Square_" + row + "_" + col; // Name the square for easier debugging
                square.transform.parent = rowParent.transform; // Set the square's parent as the current row

                // If the square is in the top row, store its transform in the topRowSquares list
                if (row == rows)
                {
                    topRowSquares.Add(square.transform);
                }
            }
        }

        // Adjust the game board's position slightly for better alignment
        gameBoard.transform.position = new Vector3(0, -0.5f, 0);

        // Set colors for the squares on the game board
        SetGameBoardColors(gameBoard);
    }

    // Method to set outline colors for all squares on the game board
    void SetGameBoardColors(GameObject gameBoard)
    {
        // Loop through each row in the game board
        foreach (Transform row in gameBoard.transform)
        {
            // Loop through each square (cell) in the current row
            foreach (Transform cell in row)
            {
                Debug.Log(cell); // Log the cell to the console for debugging

                // Set the outline color of the square based on current color rates
                cell.GetComponent<BoardCellColor>().SetOutlineColorByValue(redRate, greenRate, blueRate);

                // Decrease the color rates slightly for a gradient effect
                redRate -= .005f % 1; // Gradually decrease red intensity
                blueRate -= .003f;    // Gradually decrease blue intensity
                greenRate -= 0;       // Green remains constant (not altered)
            }
        }
    }
}
