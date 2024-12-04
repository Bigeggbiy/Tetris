using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoController : MonoBehaviour
{
    public BlockCollisionCheck squareCollisonScript;
    public LockTetromino LockBlockScript;
    public UserControls userMovementScript;
    public TetrominoSpawner newSpawn;
    public lineClear clearline;

    private Vector3 lastPosition; // Store the last known position
    private Quaternion lastRotation;

    // Initial time between downward steps (in seconds)
    // Static field for the default time interval between tetromino falls
    private static float _fallInterval = 2f;

    // Public property to allow other scripts, such as TetrominoSpawner, to access and modify the fall interval
    public float fallInterval
    {
        get { return _fallInterval; }
        set { _fallInterval = value; }
    }

    // Static field to track elapsed time since the game started
    private static float elapsedTime = 0f;

    // Constant for the interval at which the falling speed increases (every 30 seconds)
    private const float speedIncreaseInterval = 30f;

    // Constant multiplier to reduce the fall interval by 10% each speed increase
    private const float speedMultiplier = 0.9f;

    // Boolean flag to determine whether the tetromino is still falling
    private bool isFalling = true;

    void Start()
    {
        // Initialize scripts attached to this object or the main camera
        squareCollisonScript = GetComponentInChildren<BlockCollisionCheck>();
        userMovementScript = GetComponent<UserControls>();
        LockBlockScript = GetComponent<LockTetromino>();
        newSpawn = Camera.main.GetComponent<TetrominoSpawner>();


        // Start the coroutine to handle tetromino falling
        StartCoroutine(FallCoroutine());
    }

    void Update()
    {
        // Handle user inputs for controlling the tetromino
        userMovementScript.UserInput();

        // Increment the elapsed time by the time since the last frame
        elapsedTime += Time.deltaTime;

        // Check if the time interval for increasing speed has been reached
        if (elapsedTime >= speedIncreaseInterval)
        {
            elapsedTime = 0f; // Reset the timer
            fallInterval *= speedMultiplier; // Reduce the fall interval by 10%
            fallInterval = Mathf.Max(fallInterval, 0.1f); // Ensure fallInterval doesn't go below 0.1 seconds
        }
    }

    // Coroutine to handle the falling behavior of the tetromino
    private IEnumerator FallCoroutine()
    {
        while (isFalling)
        {
            float currentFallInterval = fallInterval; // Store the current fall interval

            // Wait for the fall interval before executing the next move
            yield return new WaitForSeconds(fallInterval);

            // Move the tetromino down by one grid space
            userMovementScript.MoveDown();

            // Check if the tetromino has stopped moving (no change in position or rotation)
            if (transform.position == lastPosition && transform.rotation == lastRotation)
            {
                // Lock the tetromino in place
                LockBlockScript = GetComponent<LockTetromino>();
                LockBlockScript.SetCorrectAttributes();

                // Spawn the next tetromino
                newSpawn.SpawnTetromino(fallInterval);

                // Stop the falling behavior
                isFalling = false;
            }

            // Update the last known position and rotation of the tetromino
            lastPosition = transform.position;
            lastRotation = transform.rotation;
        }
    }

}