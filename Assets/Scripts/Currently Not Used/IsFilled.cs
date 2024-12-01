using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class IsFilled : MonoBehaviour
{
    public string targetTag = "Tetromino";
    public float detectionRadius = 0.5f;
    public bool hasTetromino;

    // Update is called once per frame
    void Update()
    {
        //DetectOverlap();
    }

    void DetectOverlap()
    {
        // Loop through each row of the game board
        foreach (Transform row in transform)
        {
            // Loop through each cell in the row
            foreach (Transform cell in row.transform)
            {
                
                Collider2D cellCollider = cell.GetComponent<Collider2D>();
            
                if (cellCollider != null)
                {
                    // Check if overlapping with any colliders with the target tag
                    Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(cell.position, detectionRadius);

                    foreach (Collider2D collider in overlappingColliders)
                    {
                        if (collider.CompareTag(targetTag))
                        {
                            Square hasPieceBool = cell.GetComponent<Square>();
                            hasPieceBool.hasPiece = true;
                        }
                        else
                        {
                            Square hasPieceBool = cell.GetComponent<Square>();
                            hasPieceBool.hasPiece = false;
                        }
                    }


                }
            }
        }
    }
}
