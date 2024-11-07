using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Add this directive

public class UserControls : MonoBehaviour
{
    public float moveDistance = 1f; // Pieces move 1 unit per input

    private Rigidbody2D tetrominoRB;
    void Start() // Fixed casing for Start method
    {
        tetrominoRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            RotateTetromino();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePiece(Vector3.left);
            if (!canMove()) { // checks if block was moved to a valid spot, and moves it back if not
                MovePiece(Vector3.right);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePiece(Vector3.right);
            if (!canMove()) {
                MovePiece(Vector3.left);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePiece(Vector3.down);
            if (!canMove()) {
                MovePiece(Vector3.up);
            }
        }
    }

    void MovePiece(Vector3 direction)
    {
        transform.position += direction * moveDistance;
    }

    void RotateTetromino()
    {
        ///need to be implimented
    }

   public bool canMove()
    {
        foreach (Transform children in transform)
        {
            int xPos = Mathf.RoundToInt(children.transform.position.x);
            int yPos = Mathf.RoundToInt(children.transform.position.y); // gets position of blocks

            // checks if blocks are in-bounds
            if (xPos <-4 || xPos >= 6 || yPos < -8 || yPos >= 12)
            {
                return false;
            }
        }
        return true;
    }
}
