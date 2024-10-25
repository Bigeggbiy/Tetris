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

    private Timer spawnTimer;
    private GameInitializer gameSpeed;
    private CreateGameBoard gameBoard;  // Reference to the game board

    private List<GameObject> tetrominoPrefabs;

    void Start()
    {
        gameSpeed = GetComponent<GameInitializer>();
        if (gameSpeed == null)
        {
            Debug.LogError("GameInitializer component is missing!");
            return;
        }

        gameBoard = FindObjectOfType<CreateGameBoard>();
        if (gameBoard == null || gameBoard.topRowSquares.Count == 0)
        {
            Debug.LogError("Game board or top row squares not initialized!");
            return;
        }

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = gameSpeed.GetSpeed();
        spawnTimer.OnTimerFinished.AddListener(SpawnTetromino);
        spawnTimer.Run();

        tetrominoPrefabs = new List<GameObject>
        {
            tetrominoI, tetrominoJ, tetrominoL,
            tetrominoO, tetrominoS, tetrominoT, tetrominoZ
        };
    }

    /// <summary>
    /// Spawns a random Tetromino at a random square in the top row.
    /// </summary>
    void SpawnTetromino()
    {
        if (tetrominoPrefabs.Count == 0) return;

        // Select a random tetromino prefab
        GameObject randomTetromino = tetrominoPrefabs[Random.Range(0, tetrominoPrefabs.Count)];

        // Select a random square from the top row
        Transform randomSquare = gameBoard.topRowSquares[Random.Range(0, gameBoard.topRowSquares.Count)];

        // Instantiate the tetromino at the square's position
        GameObject newTetromino = Instantiate(randomTetromino, randomSquare.position, Quaternion.identity);

        // Set the tetromino's falling speed (optional)
        Rigidbody2D rb = newTetromino.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0, -gameSpeed.GetSpeed());
        }

        // Restart the timer for the next spawn
        spawnTimer.Duration = gameSpeed.GetSpeed();
        spawnTimer.Run();
    }

    public void HandleGameOver()
    {
        spawnTimer.Pause();
    }
}
