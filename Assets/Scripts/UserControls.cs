using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControls : MonoBehaviour
{
    public float moveDistance = 1f; // Pieces move 1 unit per input

    // Update is called once per frame
    void Update()
    {
        // Detect left arrow key input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePiece(Vector3.left); // Moves piece to the left
        }

        // Detect right arrow key input
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePiece(Vector3.right); //Moves piece to the right
        }

        // Detect down key input
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePiece(Vector3.down); // Moves piece down
        }
        
    }
    /* You can also use GetKey() instead of GetKeyDown() to hold down an arrow key and contiuously
    move, but this moves the pieces super fast and is hard to control without further enhancements, 
    we can improve this in V.2  */
    
    
    // Funtion to move pieces in a given direction
    void MovePiece(Vector3 direction)
    {
        transform.position += direction * moveDistance;
    }
}
