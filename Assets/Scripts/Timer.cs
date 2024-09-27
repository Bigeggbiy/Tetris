using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A timer.
/// </summary>
public class Timer : MonoBehaviour
{
	#region Fields

	// Timer duration
	private float totalSeconds = 0;

	// Timer execution
	private float elapsedSeconds = 0;
	private bool running = false;

	// Support for Finished property
	private bool started = false;

	#endregion

	#region Properties

	/// <summary>
	/// Sets the duration of the timer.
	/// The duration can only be set if the timer isn't currently running.
	/// </summary>
	public float Duration
	{
		get { return totalSeconds; } // used in GameInitializer.cs
		set
		{
			if (!running)
			{
				totalSeconds = value;
			}
		}
	}

	/// <summary>
	/// Gets whether or not the timer has finished running.
	/// This property returns false if the timer has never been started.
	/// </summary>
	public bool Finished
	{
		get { return started && !running; }
	}

	/// <summary>
	/// Gets whether or not the timer is currently running.
	/// </summary>
	public bool Running
	{
		get { return running; }
	}

	/// <summary>
	/// Gets the elapsed time of the timer.
	/// </summary>
	public float ElapsedTime
	{
		get { return elapsedSeconds; }
	}

	#endregion

	#region Methods

	// Update is called once per frame
	void Update()
	{
		// Update timer and check for finished
		if (running)
		{
			elapsedSeconds += Time.deltaTime;

			if (elapsedSeconds >= totalSeconds && totalSeconds != -1)
			{
				running = false;
				OnTimerFinished?.Invoke();
			}
		}
	}

	/// <summary>
	/// Runs the timer.
	/// The timer only runs if the total seconds is larger than 0.
	/// </summary>
	public void Run()
	{
		// Only run with valid duration
		if (totalSeconds > 0 || totalSeconds == -1)
		{
			started = true;
			running = true;
			elapsedSeconds = 0;
		}
	}

	/// <summary>
	/// Pauses the timer.
	/// </summary>
	public void Pause()
	{
		if (running)
		{
			running = false;
		}
	}

	/// <summary>
	/// Resumes the timer if it was paused.
	/// </summary>
	public void Resume()
	{
		if (started && !running)
		{
			running = true;
		}
	}

	/// <summary>
	/// Stops the timer and resets it.
	/// </summary>
	public void Reset()
	{
		running = false;
		started = false;
		elapsedSeconds = 0;
	}

	/// <summary>
	/// UnityEvent that gets called when the timer finishes.
	/// </summary>
	public UnityEvent OnTimerFinished = new UnityEvent();

	#endregion
}
