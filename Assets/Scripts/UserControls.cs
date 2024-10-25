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
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePiece(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePiece(Vector3.down);
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

   
}
