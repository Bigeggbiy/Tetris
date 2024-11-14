using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollisionCheck : MonoBehaviour
{
    //public float detectionRange = 1f;     // Range of the raycast
    //public LayerMask detectionLayer;       // Layer of objects to detect
    //public float offsetDistance = 0.1f;    // Offset to avoid overlap detection
    //public string TetrominoTag = "Tetromino";
    //public float detectionRadius = .5f;

    //public bool SquareCollisionCheck(Vector2 direction)
    //{
    //    // Offset the start position of the ray slightly to avoid overlap
    //    Vector2 rayStartPosition = (Vector2)transform.position + direction * offsetDistance;

    //    // Perform the raycast
    //    RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, direction, detectionRange, detectionLayer);

    //    // Check for hits, excluding itself if necessary
    //    if (hit.collider != null && hit.collider.gameObject != gameObject)
    //    {
    //        if (hit.collider.CompareTag(TetrominoTag))
    //        {
    //            return true;
    //        }

    //    }
    //    return false;
    //}
}
