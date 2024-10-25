using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public float initialFallSpeed = 2f; // Default fall speed (2 units per second down)
    public float speedIncreaseInterval = 30f; // Increase speed every 30 seconds
    public float speedIncreaseAmount = 0.1f; // Increase speed by 0.1 units each time

    private float currentFallSpeed;

    void Awake()
    {
        ScreenUtils.Initialize();
    }

    void Start()
    {
        currentFallSpeed = initialFallSpeed; // Set initial speed
        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedIncreaseInterval);
            currentFallSpeed += speedIncreaseAmount; // Increase speed over time
        }
    }

    public float GetSpeed()
    {
        // speed is negative so the tetromino falls down
        return -Mathf.Abs(currentFallSpeed);
    }
}
