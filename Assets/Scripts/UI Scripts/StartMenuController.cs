using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main scene"); // Replace with your game scene name
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!"); // Only works in a built application
    }
}
