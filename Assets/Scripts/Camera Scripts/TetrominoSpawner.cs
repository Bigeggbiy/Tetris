using System.Collections.Generic;
using UnityEngine;

public class TetrominoSpawner : MonoBehaviour
{
    [SerializeField] GameObject tetrominoI;
    [SerializeField] GameObject tetrominoJ;
    [SerializeField] GameObject tetrominoL;
    [SerializeField] GameObject tetrominoO;
    [SerializeField] GameObject tetrominoS;
    [SerializeField] GameObject tetrominoT;
    [SerializeField] GameObject tetrominoZ;

    private CreateGameBoard gameBoard;  // Reference to the game board

    private List<GameObject> tetrominoPrefabs;

    private List<GameObject> recentTetrominos = new List<GameObject>();
    private int maxRecentCount = 3;
    public Transform previewArea; 
    private GameObject nextTetrominoPreview; // To store the current preview instance
    private List<GameObject> nextTetrominos = new List<GameObject>();

    void Start()
    {
        // Find the CreateGameBoard component in the scene to initialize the game board
        gameBoard = FindObjectOfType<CreateGameBoard>();

        // Check if the game board or its top row squares are not initialized
        if (gameBoard == null || gameBoard.topRowSquares.Count == 0)
        {
            Debug.LogError("Game board or top row squares not initialized!");
            return; // Exit if initialization fails
        }

        // Initialize the list of Tetromino prefabs
        tetrominoPrefabs = new List<GameObject>
        {
        tetrominoI, tetrominoJ, tetrominoL,
        tetrominoO, tetrominoS, tetrominoT, tetrominoZ
        };

        // Define the initial interval for Tetromino fall (in seconds)
        float initialFallInterval = 0.5f;

        // Spawn the first Tetromino at the start of the game
        SpawnTetromino(initialFallInterval);
    }

    public GameObject CreateNextTetromino()
    {
        // Remove the first Tetromino in the queue if there are any
        if (nextTetrominos.Count > 0)
        {
            nextTetrominos.RemoveAt(0);
        }

        // Ensure the nextTetrominos list always has at least 2 Tetrominos
        while (nextTetrominos.Count < 2)
        {
            GameObject randomTetromino = null;
            int attempts = 0;

            // Keep selecting a random Tetromino until it's not in recent or upcoming lists
            while (randomTetromino == null || recentTetrominos.Contains(randomTetromino) || nextTetrominos.Contains(randomTetromino))
            {
                randomTetromino = tetrominoPrefabs[Random.Range(0, tetrominoPrefabs.Count)];
                attempts++;

                // Prevent infinite loop by breaking after 50 attempts
                if (attempts > 50) break;
            }

            // Add the selected Tetromino to the upcoming and recent lists
            nextTetrominos.Add(randomTetromino);
            recentTetrominos.Add(randomTetromino);

            // Ensure recentTetrominos doesn't exceed the allowed history size
            if (recentTetrominos.Count > maxRecentCount)
            {
                recentTetrominos.RemoveAt(0);
            }
        }

        // Update the preview display for the next Tetromino
        UpdatePreview(nextTetrominos[1]);

        // Ensure recentTetrominos doesn't exceed the allowed history size (again, for safety)
        if (recentTetrominos.Count > maxRecentCount)
        {
            recentTetrominos.RemoveAt(0);
        }

        // Return the first Tetromino in the queue for spawning
        return nextTetrominos[0];
    }

    private void UpdatePreview(GameObject nextTetromino)
    {
        // Remove the current preview instance if it exists
        if (nextTetrominoPreview != null)
        {
            Destroy(nextTetrominoPreview);
        }

        // Instantiate a preview Tetromino in the preview area
        nextTetrominoPreview = Instantiate(nextTetromino, previewArea.position, Quaternion.identity);

        // Disable gameplay-related components for the preview
        nextTetrominoPreview.GetComponent<TetrominoController>().enabled = false;
        nextTetrominoPreview.GetComponent<UserControls>().enabled = false;

        // Adjust the Z position to ensure the preview appears in front of the background
        Vector3 adjustedPosition = nextTetrominoPreview.transform.position;
        adjustedPosition.z = -0.1f;
        nextTetrominoPreview.transform.position = adjustedPosition;

        // Set the parent of the preview to the preview area
        nextTetrominoPreview.transform.SetParent(previewArea, true);
    }

    public void SpawnTetromino(float currentFallInterval)
    {
        // Return early if there are no Tetromino prefabs available
        if (tetrominoPrefabs.Count == 0) return;

        // Generate the next Tetromino to spawn
        GameObject randomTetromino = CreateNextTetromino();

        // Select the 5th square (center) in the top row for spawning
        Transform randomSquare = gameBoard.topRowSquares[4];

        // Instantiate the Tetromino at the specified position
        GameObject newTetromino = Instantiate(randomTetromino, randomSquare.position, Quaternion.identity);

        // Set the Tetromino's fall interval
        TetrominoController tetrominoController = newTetromino.GetComponent<TetrominoController>();
        if (tetrominoController != null)
        {
            tetrominoController.fallInterval = currentFallInterval; // Pass the updated interval
        }

        // Special adjustments for specific Tetromino shapes
        if (randomTetromino == tetrominoI)
        {
            newTetromino.transform.Translate(0.5f, -0.5f, 0); // Offset for Tetromino I
        }
        else if (randomTetromino == tetrominoO)
        {
            newTetromino.transform.Translate(-0.5f, -0.5f, 0); // Offset for Tetromino O
        }
    }

}
