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




    //private UserControls userControls;
    public float fallInterval = 2f; // Time between downward steps (in seconds)
    //private GameInitializer gameInitializer;
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
    }

    private IEnumerator FallCoroutine()
    {
        while (isFalling)
        {
            yield return new WaitForSeconds(fallInterval);

            userMovementScript.MoveDown();
            if (transform.position == lastPosition)
            {
                LockBlockScript = GetComponent<LockTetromino>();
                LockBlockScript.SetCorrectAttributes();
                newSpawn.SpawnTetromino();

                isFalling = false;
            }

            lastPosition = transform.position;
        }
    }
}
