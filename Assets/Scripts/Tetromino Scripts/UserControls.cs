using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events; // Add this directive
using static Unity.VisualScripting.Metadata;

public class UserControls : MonoBehaviour
{
    public float moveDistance = 1f; // Pieces move 1 unit per input
                                   
    void Start() 
    {
        
    }

    public void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!DetectCollision(Vector2.left))
            {
                MovePiece(Vector3.left);
            }

            if (!canMove())
            { // checks if block was moved to a valid spot, and moves it back if not
                MovePiece(Vector3.right);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!DetectCollision(Vector2.right))
            {
                MovePiece(Vector3.right);
            }

            if (!canMove())
            { // checks if block was moved to a valid spot, and moves it back if not
                MovePiece(Vector3.left);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!DetectCollision(Vector2.down))
            {
                MovePiece(Vector3.down);
            }

            if (!canMove())
            { // checks if block was moved to a valid spot, and moves it back if not
                MovePiece(Vector3.up);
            }
        }
    }
    public void MoveDown()
    {
        if (!DetectCollision(Vector2.down))
        {
            MovePiece(Vector3.down);
        }

        if (!canMove())
        { // checks if block was moved to a valid spot, and moves it back if not
            MovePiece(Vector3.up);
        }
    }

    bool DetectCollision(Vector2 direction)
    {
        foreach (Transform child in transform)
        {
            // Get the ChildScript component from the child object
            BlockCollisionCheck childScript = child.GetComponent<BlockCollisionCheck>();

            // If any child has the condition met, ignore the key press
            if (childScript != null && childScript.SquareCollisionCheck(direction))
            {
                return true; // Exit the method early to ignore the key press
            }
        }

        return false;
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
            if (xPos < -4 || xPos >= 6 || yPos < -8 || yPos >= 12)
            {
                return false;
            }
        }
        return true;
    }
}
