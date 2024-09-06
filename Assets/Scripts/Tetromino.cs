using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Tetromino
/// </summary>
public class Tetromino : MonoBehaviour
{
    [SerializeField]
    Sprite Tetris_piece_O;
    [SerializeField]
    Sprite Tetris_piece_S;
    [SerializeField]
    Sprite Tetris_piece_Z;
    [SerializeField]
    Sprite Tetris_piece_T;
    [SerializeField]
    Sprite Tetris_piece_L;
    [SerializeField]
    Sprite Tetris_piece_J;
    [SerializeField]
    Sprite Tetris_piece_I;

    private Rigidbody2D tetrominoRB;

    // Start is called before the first frame update
    void Start()
    {
        // Set random sprite for tetromino
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 7); // Adjusted range to include all pieces

        switch (spriteNumber)
        {
            case 0:
                spriteRenderer.sprite = Tetris_piece_O;
                break;
            case 1:
                spriteRenderer.sprite = Tetris_piece_S;
                break;
            case 2:
                spriteRenderer.sprite = Tetris_piece_Z;
                break;
            case 3:
                spriteRenderer.sprite = Tetris_piece_T;
                break;
            case 4:
                spriteRenderer.sprite = Tetris_piece_L;
                break;
            case 5:
                spriteRenderer.sprite = Tetris_piece_J;
                break;
            case 6:
                spriteRenderer.sprite = Tetris_piece_I;
                break;
        }

        tetrominoRB = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Initializes the tetromino and sets its starting location
    /// </summary>
    public void Initialize(Vector3 location)
    {
        transform.position = location;
    }

    // Update is called once per frame
    void Update()
    {
        // Move tetromino left, right, down
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            RotateTetromino();
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            MoveTetromino(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            MoveTetromino(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            MoveTetromino(Vector3.right);
        }
    }

    // Moves the tetromino in the given direction
    void MoveTetromino(Vector3 direction)
    {
        transform.position += direction;
    }

    // Rotates the tetromino 90 degrees clockwise
    void RotateTetromino()
    {
        transform.Rotate(0, 0, -90);
    }
}