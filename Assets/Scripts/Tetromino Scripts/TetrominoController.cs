using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoController : MonoBehaviour
{
    public BlockCollisionCheck squareCollisonScript;
    public LockTetromino LockBlockScript;
    public UserControls userMovementScript;
    public TetrominoSpawner newSpawn;

    private Vector3 lastPosition; // Store the last known position
    private Quaternion lastRotation;

    // Initial time between downward steps (in seconds)
    private static float _fallInterval = 2f;
    public float fallInterval // So TetrominoSpawner can access
    {
        get { return _fallInterval; }
        set { _fallInterval = value; }
    }
    private static float elapsedTime = 0f; // Tracks time since game start
    private const float speedIncreaseInterval = 30f; // Speed increases after 30 seconds
    private const float speedMultiplier = 0.9f; // Multiplier to reduce fallInterval to 90% of its current value
    private bool isFalling = true;

    void Start()
    {
        squareCollisonScript = GetComponentInChildren<BlockCollisionCheck>();
        userMovementScript = GetComponent<UserControls>();
        LockBlockScript = GetComponent<LockTetromino>();
        newSpawn = Camera.main.GetComponent<TetrominoSpawner>();



        StartCoroutine(FallCoroutine());


        //userControls = GetComponent<UserControls>(); // reference to userControls
        //gameInitializer = FindObjectOfType<GameInitializer>();
        //if (gameInitializer != null)
        //{
        //    // Calculate initial fall interval based on game speed
        //    fallInterval = Mathf.Abs(1f / gameInitializer.GetSpeed());
        //    StartCoroutine(FallCoroutine());
        //}
    }

    void Update()
    {
        userMovementScript.UserInput();

        // Update timer
        elapsedTime += Time.deltaTime;

        // Check if 30 seconds have passed
        if (elapsedTime >= speedIncreaseInterval)
        {
            elapsedTime = 0f; // Reset timer
            fallInterval *= speedMultiplier; // Decrease fallInterval
            fallInterval = Mathf.Max(fallInterval, 0.1f); // Set minimum value for fallInterval
            //Debug.Log($"Increased speed, new fallInterval is {fallInterval}");

        }
    }

    private IEnumerator FallCoroutine()
    {
        while (isFalling)
        {
            float currentFallInterval = fallInterval;
            //Debug.Log("Waiting for fall interval: " + fallInterval);
            yield return new WaitForSeconds(fallInterval);

            //Debug.Log("Tetromino moved down.");
            userMovementScript.MoveDown();

            if (transform.position == lastPosition && transform.rotation == lastRotation)
            {
                LockBlockScript = GetComponent<LockTetromino>();
                LockBlockScript.SetCorrectAttributes();
                newSpawn.SpawnTetromino(fallInterval);

                isFalling = false;
            }

            lastPosition = transform.position;
            lastRotation = transform.rotation;
        }
    }
}