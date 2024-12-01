using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public bool hasPiece;

    // Start is called before the first frame update
    void Start()
    {
        hasPiece = false;
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // Check if the colliding object has the "Tetromino" tag
    //    if (collision.gameObject.CompareTag("Tetromino"))
    //    {
    //        hasPiece = true;
    //    }
    //}

    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    // When the Tetromino leaves, reset the state
    //    if (collision.gameObject.CompareTag("Tetromino"))
    //    {
    //        hasPiece = false;
    //    }
    //}
}

