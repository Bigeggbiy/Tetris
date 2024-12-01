using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{
    private CreateGameBoard topRowScript;
    private List<Transform> topRowTransforms;
    private string targetTag = "Tetromino";
    // Start is called before the first frame update
    void Start()
    {
        topRowScript = GetComponent<CreateGameBoard>();
        topRowTransforms = topRowScript.topRowSquares;
    }

    public bool CheckTopRow()
    {
        foreach (Transform cell in topRowTransforms)
        {
            // Check if this cell contains a tetromino
            Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(cell.position, 0.5f);

            foreach (Collider2D collider in overlappingColliders)
            {
                if (collider.CompareTag(targetTag))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
