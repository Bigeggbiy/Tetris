using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    public GameObject gameOverUI;
    private bool isPaused = false;


    private void Start()
    {
        ResumeGame();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Escape key toggles pause
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        Time.timeScale = 1f; // Resume game time
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Freeze game time
        isPaused = true;

    }

    public void RestartGame()
    {
        ResumeGame();
        SceneManager.LoadScene("Game Scene");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }


    public void EndGame()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // Freeze game time
        isPaused = true;
    }
}
