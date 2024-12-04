using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public float fallInterval;
    public float baseSpeed = 1;


    // Start is called before the first frame update
    void Start()
    {
        fallInterval = baseSpeed;
    }

    public void IncreaseFallSpeed(int level)
    {
        fallInterval = baseSpeed * Mathf.Pow(0.8f, level);
    }
}
