using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Add this directive

public class blocks : MonoBehaviour
{
    public UnityEvent GameOverEvent = new UnityEvent(); // Declare UnityEvent
    private Rigidbody2D tetrominoRB;

    void Start() // Fixed casing for Start method
    {
        tetrominoRB = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        stopFall();
    }

    void stopFall()
    {

        if (tetrominoRB != null)
        {
            tetrominoRB.velocity = Vector2.zero;
            tetrominoRB.bodyType = RigidbodyType2D.Kinematic;
        }

        if (transform.position.y > ScreenUtils.ScreenTop)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        GameOverEvent?.Invoke(); // Invoke the GameOver event
        Destroy(gameObject);
    }
}
