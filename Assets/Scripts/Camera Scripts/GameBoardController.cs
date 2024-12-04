using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameBoardController : MonoBehaviour
{
    // References to various game components
    private lineClear clearLines; 
    private Scoring scoring; 
    private GameObject gameBoard; 
    private Levels level; 
    private GameOverCheck checkGameOver; 

    public GameObject UIScriptObject;


    public int totalScore = 0;
    public int currentLevel = 0;

    void Start()
    {
        gameBoard = GameObject.FindWithTag("Game Board"); // Locate the game board object using its tag
        clearLines = gameBoard.GetComponent<lineClear>(); // Attach the lineClear component from the game board
        scoring = GetComponent<Scoring>(); // Attach the Scoring component from the current object
        level = GetComponent<Levels>(); // Attach the Levels component from the current object
        checkGameOver = GetComponent<GameOverCheck>(); // Attach the GameOverCheck component from the current object
    }

    void Update()
    {
        // Check if the blocks reach the top row
        if (checkGameOver.CheckTopRow())
        {
            // Trigger the end-game logic through the pause menu controller
            UIScriptObject.GetComponent<PauseMenuController>().EndGame();
            return; // Exit the Update method to avoid further processing
        }

        // Check and clear any filled rows, and get the number of cleared lines
        int linesCleared = clearLines.CheckAndClearFilledRows();

        // Update the current level based on the number of lines cleared
        currentLevel = level.DetermineLevel(linesCleared);

        // Calculate and add score based on cleared lines and current level
        totalScore += scoring.CalculateScore(linesCleared, currentLevel, 0);
    }
}
