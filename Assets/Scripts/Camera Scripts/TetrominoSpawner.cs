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

    //private Timer spawnTimer;
    //private GameInitializer gameSpeed;
    private CreateGameBoard gameBoard;  // Reference to the game board

    private List<GameObject> tetrominoPrefabs;

    private List<GameObject> recentTetrominos = new List<GameObject>();
    private int maxRecentCount = 3;
    public Transform previewArea; // Assign in the Inspector
    private GameObject nextTetrominoPreview; // To store the current preview instance
    private List<GameObject> nextTetrominos = new List<GameObject>();

    void Start()
    {

        gameBoard = FindObjectOfType<CreateGameBoard>();
        if (gameBoard == null || gameBoard.topRowSquares.Count == 0)
        {
            Debug.LogError("Game board or top row squares not initialized!");
            return;
        }


        tetrominoPrefabs = new List<GameObject>
        {
            tetrominoI, tetrominoJ, tetrominoL,
            tetrominoO, tetrominoS, tetrominoT, tetrominoZ
        };
        float initialFallInterval = .5f; // Initially falls every 2 seconds
        SpawnTetromino(initialFallInterval);
    }

    public GameObject CreateNextTetromino()
    {

        if (nextTetrominos.Count > 0) 
        { 
            nextTetrominos.RemoveAt(0); 
        }

        while (nextTetrominos.Count < 2)
        {
            GameObject randomTetromino = null;
            int attempts = 0;

            // Ensure a valid Tetromino is chosen
            while (randomTetromino == null || recentTetrominos.Contains(randomTetromino) || nextTetrominos.Contains(randomTetromino))
            {
                randomTetromino = tetrominoPrefabs[Random.Range(0, tetrominoPrefabs.Count)];
                attempts++;

                // Failsafe to break infinite loop if all Tetrominos are in the recent list
                if (attempts > 50) break;
            }

            // Add to the upcoming list and recent history
            nextTetrominos.Add(randomTetromino);
            recentTetrominos.Add(randomTetromino);

            // Maintain max history size
            if (recentTetrominos.Count > maxRecentCount)
            {
                recentTetrominos.RemoveAt(0);
            }
        }

        UpdatePreview(nextTetrominos[1]);

        // Maintain max history size
        if (recentTetrominos.Count > maxRecentCount)
        {
            recentTetrominos.RemoveAt(0);
        }


        return nextTetrominos[0];
    }

    private void UpdatePreview(GameObject nextTetromino)
    {
        // Remove the previous preview instance, if any
        if (nextTetrominoPreview != null)
        {
            Destroy(nextTetrominoPreview);
        }

        // Instantiate a new preview Tetromino
        nextTetrominoPreview = Instantiate(nextTetromino, previewArea.position, Quaternion.identity);

        nextTetrominoPreview.GetComponent<TetrominoController>().enabled = false;
        nextTetrominoPreview.GetComponent<UserControls>().enabled = false;

        // Adjust the z position - (The Tetromino was being displayed behind the black background)
        Vector3 adjustedPosition = nextTetrominoPreview.transform.position;
        adjustedPosition.z = -0.1f;
        nextTetrominoPreview.transform.position = adjustedPosition;

        // Scale down and reposition the preview for better visibility
        //nextTetrominoPreview.transform.localScale *= 0.5f; // Adjust scale as needed
        nextTetrominoPreview.transform.SetParent(previewArea, true); // Optional: parent it to the preview area
    }

    /// Spawns a random Tetromino
    public void SpawnTetromino(float currentFallInterval)
    {
        if (tetrominoPrefabs.Count == 0) return;

        GameObject randomTetromino = CreateNextTetromino();

        //GameObject randomTetromino = tetrominoPrefabs[Random.Range(0, tetrominoPrefabs.Count)];
        Transform randomSquare = gameBoard.topRowSquares[4];

        GameObject newTetromino = Instantiate(randomTetromino, randomSquare.position, Quaternion.identity);
        //newTetromino.transform.Translate(0, 1f, 0); // So it spawns above the board

        // Preserves fall interval rate for new tetromino spawn
        TetrominoController tetrominoController = newTetromino.GetComponent<TetrominoController>();
        if (tetrominoController != null)
        {
            tetrominoController.fallInterval = currentFallInterval; // pass updated interval
        }

        // Apply half-unit translation for tetrominoI and tetrominoO
        if (randomTetromino == tetrominoI)
        {
            newTetromino.transform.Translate(0.5f, -0.5f, 0); // Move right by 0.5 units
        }
        else if (randomTetromino == tetrominoO)
        {
            newTetromino.transform.Translate(-0.5f, -0.5f, 0); // Move left by 0.5 units
        }

    }
}
