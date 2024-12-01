using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardController : MonoBehaviour
{
    private lineClear clearLines;
    private Scoring scoring;
    private GameObject gameBoard;
    private Levels level;
    private GameOverCheck checkGameOver;

    public GameObject pauseMenu;

    public int totalScore = 0;
    public int currentLevel = 0;   

    // Start is called before the first frame update
    void Start()
    {
        //clearLines = GetComponent<lineClear>();
        gameBoard = GameObject.FindWithTag("Game Board");
        clearLines = gameBoard.GetComponent<lineClear>();
        scoring = GetComponent<Scoring>();
        level = GetComponent<Levels>();
        checkGameOver = GetComponent<GameOverCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkGameOver.CheckTopRow()) 
        {
            pauseMenu.GetComponent<PauseMenuController>().EndGame();
            return;
        }
        int linesCleared = clearLines.CheckAndClearFilledRows();
        currentLevel = level.DetermineLevel(linesCleared);
        totalScore += scoring.CalculateScore(linesCleared, currentLevel, 0);
        
    }
}
