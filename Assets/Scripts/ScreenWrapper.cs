using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    // Size of the collider bounds
    Vector2 colliderSize;

    /// <summary>
	/// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Save for efficiency: size of the BoxCollider2D
        BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
        colliderSize = boxCollider.size * transform.localScale;
    }

    /// <summary>
    /// Called when the camera can no longer see the game object
    /// </summary>
    void OnBecameInvisible()
    {
        Vector2 objectPos = transform.position;

        // Check and wrap on horizontal sides
        if (objectPos.x - colliderSize.x / 2 > ScreenUtils.ScreenRight)
        {
            objectPos.x = ScreenUtils.ScreenLeft - colliderSize.x / 2;
        }
        else if (objectPos.x + colliderSize.x / 2 < ScreenUtils.ScreenLeft)
        {
            objectPos.x = ScreenUtils.ScreenRight + colliderSize.x / 2;
        }

        // Move game object to the new wrapped position
        transform.position = objectPos;
    }
}