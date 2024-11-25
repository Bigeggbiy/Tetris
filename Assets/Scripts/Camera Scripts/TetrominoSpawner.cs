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

    void Start()
    {
        //gameSpeed = GetComponent<GameInitializer>();
        //if (gameSpeed == null)
        //{
        //    Debug.LogError("GameInitializer component is missing!");
        //    return;
        //}

        gameBoard = FindObjectOfType<CreateGameBoard>();
        if (gameBoard == null || gameBoard.topRowSquares.Count == 0)
        {
            Debug.LogError("Game board or top row squares not initialized!");
            return;
        }
        //spawnTimer = gameObject.AddComponent<Timer>();
        //spawnTimer.Duration = gameSpeed.GetSpeed();
        //spawnTimer.OnTimerFinished.AddListener(SpawnTetromino);
        //spawnTimer.Run();

        tetrominoPrefabs = new List<GameObject>
        {
            tetrominoI, tetrominoJ, tetrominoL,
            tetrominoO, tetrominoS, tetrominoT, tetrominoZ
        };
        float initialFallInterval = 2f; // Initially falls every 2 seconds
        SpawnTetromino(initialFallInterval);
    }

    /// <summary>
    /// Spawns a random Tetromino at a random square in the top row.
    /// </summary>
    public void SpawnTetromino(float currentFallInterval)
    {
        if (tetrominoPrefabs.Count == 0) return;

        GameObject randomTetromino = tetrominoPrefabs[Random.Range(0, tetrominoPrefabs.Count)];
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

    /*public void HandleGameOver()
    {
        spawnTimer.Pause();
    } */
}
