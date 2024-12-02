using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    // Initial time between downward steps (in seconds)
    //private static float _fallInterval = 2f;
    public float fallInterval;
    public float baseSpeed = 1;
    //public float fallInterval // So TetrominoSpawner can access
    //{
    //    get { return _fallInterval; }
    //    set { _fallInterval = value; }
    //}
    //private static float elapsedTime = 0f; // Tracks time since game start
    //private const float speedIncreaseInterval = 30f; // Speed increases after 30 seconds
    //private const float speedMultiplier = 0.9f; // Multiplier to reduce fallInterval to 90% of its current value

    // Start is called before the first frame update
    void Start()
    {
        fallInterval = baseSpeed;
    }

    public void IncreaseFallSpeed(int level)
    {
        fallInterval = baseSpeed * Mathf.Pow(0.8f, level);
    }


    //private IEnumerator FallCoroutine()
    //{
    //    while (isFalling)
    //    {
    //        float currentFallInterval = fallInterval;
    //        //Debug.Log("Waiting for fall interval: " + fallInterval);
    //        yield return new WaitForSeconds(fallInterval);

    //        //Debug.Log("Tetromino moved down.");
    //        userMovementScript.MoveDown();

    //        if (transform.position == lastPosition && transform.rotation == lastRotation)
    //        {
    //            LockBlockScript = GetComponent<LockTetromino>();
    //            LockBlockScript.SetCorrectAttributes();
    //            //clearline.CheckAndClearFilledRows();
    //            newSpawn.SpawnTetromino(fallInterval);

    //            isFalling = false;
    //        }

    //        lastPosition = transform.position;
    //        lastRotation = transform.rotation;
    //    }
    //}
}
