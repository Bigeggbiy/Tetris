using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    Timer gameTimer;
    /// <summary>
    /// Awake is called before Start
    /// </summary>
	void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Add and set up the Timer component
        gameTimer = gameObject.AddComponent<Timer>();
        gameTimer.Duration = -1;  // Set the interval duration
        gameTimer.Run();  // Start the timer
    }

    /// <summary>
    /// Sets the speed of the game
    /// </summary>
    /// <returns></returns>
    public float GetSpeed()
    {
        float speed = Mathf.Round((gameTimer.ElapsedTime / 60) * 10) / 10 + 1;
        return speed;
    }
}
