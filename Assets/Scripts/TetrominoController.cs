using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoController : MonoBehaviour
{
    private UserControls userControls;
    public float fallInterval = 0.1f; // Time between downward steps (in seconds)
    private GameInitializer gameInitializer;
    private bool isFalling = true;

    void Start()
    {
        userControls = GetComponent<UserControls>(); // reference to userControls
        gameInitializer = FindObjectOfType<GameInitializer>();
        if (gameInitializer != null)
        {
            // Calculate initial fall interval based on game speed
            fallInterval = Mathf.Abs(1f / gameInitializer.GetSpeed());
            StartCoroutine(FallCoroutine());
        }
    }

    private IEnumerator FallCoroutine()
    {
        while (isFalling)
        {
            yield return new WaitForSeconds(fallInterval);

            // Move down one unit
            if (MovePiece(Vector3.down) == false)
            {
                // Stop falling if the piece can't move down
                isFalling = false;
            }
        }
    }

    private bool MovePiece(Vector3 direction)
    {
        transform.position += direction;
        if (!userControls.canMove())
        {
            // Move back if it collides
            transform.position -= direction;
            return false;
        }
        return true;
    }
}
