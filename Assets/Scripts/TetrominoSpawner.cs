using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabTetromino;  // The prefab for spawning tetrominoes

    [SerializeField]
    float spawnInterval = 2f;    // The interval in seconds between spawning tetrominoes

    Timer spawnTimer;            // Reference to the Timer component

    void Start()
    {
        // Add and set up the Timer component
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = spawnInterval;  // Set the interval duration
        spawnTimer.OnTimerFinished.AddListener(SpawnTetromino);  // Add listener to spawn tetromino
        spawnTimer.Run();  // Start the timer
    }

    /// <summary>
    /// Spawns a new Tetromino at the top center of the screen
    /// </summary>
    void SpawnTetromino()
    {
        // Calculate the spawn position
        Vector3 tetrominoPos = new Vector3(0, ScreenUtils.ScreenTop - 1, 0);  // Adjust the Y offset as needed

        // Instantiate and initialize the tetromino
        GameObject tetromino = Instantiate(prefabTetromino, tetrominoPos, Quaternion.identity);
        tetromino.GetComponent<Tetromino>().Initialize(tetrominoPos);

        // Restart the timer for the next spawn
        spawnTimer.Run();
    }
}