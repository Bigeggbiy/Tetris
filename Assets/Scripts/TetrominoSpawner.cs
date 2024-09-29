using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabTetromino;  // The prefab for spawning tetrominoes

    Timer spawnTimer;            // Reference to the Timer component
    GameInitializer gameSpeed;   // Reference to the GameInitializer component

    void Start()
    {
        gameSpeed = gameObject.GetComponent<GameInitializer>();  // Get the GameInitializer component

        // Add and set up the Timer component
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = gameSpeed.GetSpeed();  // Set the interval duration
        spawnTimer.OnTimerFinished.AddListener(SpawnTetromino);  // Add listener to spawn tetromino
        spawnTimer.Run();  // Start the timer
    }

    /// <summary>
    /// Spawns a new Tetromino at the top center of the screen
    /// </summary>
    void SpawnTetromino()
    {
        // Calculate the spawn position
        float randomPosition = Mathf.Round(Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight)); // Randomize the position of the tetromino
        Vector3 tetrominoPos = new Vector3(randomPosition, ScreenUtils.ScreenTop, 0);

        // Set the speed of the tetromino
        float speed = gameSpeed.GetSpeed();  // Adjust the speed as needed

        // Instantiate and initialize the tetromino
        GameObject tetromino = Instantiate(prefabTetromino, tetrominoPos, Quaternion.identity);
        tetromino.GetComponent<Tetromino>().Initialize(tetrominoPos, speed);

        spawnTimer.Duration = speed; // Update spawn timer based on speed

        // Restart the timer for the next spawn
        spawnTimer.Run();
    }

    void HandleGameOver()
    {
        spawnTimer.Pause();
    }
}
