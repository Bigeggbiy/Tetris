using System.Collections.Generic;
using UnityEngine;

public class CreateGameBoard : MonoBehaviour
{
    public GameObject squarePrefab; // Reference to the square prefab
    public int columns = 10; // Number of squares per row
    public int rows = 20;    // Number of rows
    public float squareSize = 1f; // Size of each square

    public List<Transform> topRowSquares = new List<Transform>();  // Stores positions of squares in the top row

    void Awake(){
    CreateBoard();  // Create the board early
    }   

    private void CreateBoard(){
    // Create the main parent object called "GameBoard"
    GameObject gameBoard = new GameObject("GameBoard");

    float xOffset = (columns * squareSize) / 2f;
    float yOffset = (rows * squareSize) / 2f;

    for (int row = 1; row <= rows; row++)
    {
        GameObject rowParent = new GameObject("Row_" + row);
        rowParent.transform.parent = gameBoard.transform;

        for (int col = 1; col <= columns; col++)
        {
            float xPos = (col * squareSize) - xOffset;
            float yPos = (row * squareSize) - yOffset + 1;

            GameObject square = Instantiate(squarePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
            square.name = "Square_" + row + "_" + col;
            square.transform.parent = rowParent.transform;

            if (row == rows)  // Store top row squares
            {
                topRowSquares.Add(square.transform);
            }
        }
    }

    gameBoard.transform.position = new Vector3(0, -0.5f, 0);
    }
}
