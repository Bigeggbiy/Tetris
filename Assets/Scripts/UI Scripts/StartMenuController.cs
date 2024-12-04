using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
