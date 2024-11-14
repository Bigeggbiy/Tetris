using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events; // Add this directive
using static Unity.VisualScripting.Metadata;

public class UserControls : MonoBehaviour
{
    public float moveDistance = 1f; // Pieces move 1 unit per input
    public string TetrominoTag = "Tetromino";
    public float detectionRadius = .5f;

    void Start() 
    {
        
    }

    public void UserInput()
    {
        // Each of these take a keypress, move the piece, check if the move was valid, and if not move it back
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation *= Quaternion.Euler(0, 0, -90);
            
            if (CollisionCheck(gameObject) || !canMove())
            {
                transform.rotation *= Quaternion.Euler(0, 0, 90);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePiece(Vector3.left);
            if (CollisionCheck(gameObject) || !canMove())
            {
                MovePiece(Vector3.right);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePiece(Vector3.right);
            if (CollisionCheck(gameObject) || !canMove())
            {
                MovePiece(Vector3.left);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            MovePiece(Vector3.down);
            if (CollisionCheck(gameObject) || !canMove())
            {
                MovePiece(Vector3.up);
            }
        }
    }


    public bool CollisionCheck(GameObject TetrominoPiece)
    {
        // Iterates through each block in a piece and checks if it collides with another Tetromino
        foreach (Transform block in TetrominoPiece.transform)
        {
            Collider2D blockCollider = block.GetComponent<Collider2D>();
            if (blockCollider != null)
            {
                // Check if overlapping with any colliders with the target tag
                Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(block.position, detectionRadius);

                foreach (Collider2D collider in overlappingColliders)
                {
                    if (collider.CompareTag(TetrominoTag))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }


    public void MoveDown()
    {
        MovePiece(Vector3.down);
        if (CollisionCheck(gameObject) || !canMove())
        {
            MovePiece(Vector3.up);
        }
    }

    void MovePiece(Vector3 direction)
    {
        transform.position += direction * moveDistance;
    }

    public bool canMove()
    {
        foreach (Transform children in transform)
        {
            int xPos = Mathf.RoundToInt(children.transform.position.x);
            int yPos = Mathf.RoundToInt(children.transform.position.y); // gets position of blocks

            // checks if blocks are in-bounds
            if (xPos < -4 || xPos >= 6 || yPos < -9 || yPos >= 12)
            {
                return false;
            }
        }
        return true;
    }
}
