using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    Timer gameTimer;
    /// <summary>
    /// Awake is called before Start
    /// </summary>
    public float initialFallSpeed = 10f; // Initial speed, default 1f
    public float speedIncreaseInterval = 0.01f; // Time in seconds to increase speed, default 30f
    public float speedIncreaseAmount = 700000000f; // default .1f Speed increase amount

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

        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedIncreaseInterval);
            gameTimer.Duration = Mathf.Max(0.1f, gameTimer.Duration - speedIncreaseAmount);
        }
    }

    /// <summary>
    /// Sets the speed of the game
    /// </summary>
    /// <returns></returns>
    public float GetSpeed()
    {
        float speed = Mathf.Round((gameTimer.ElapsedTime / 60) * 10) / 10 + initialFallSpeed;
        return speed;
    }
}
