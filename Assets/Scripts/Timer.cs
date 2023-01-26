using System;
using UnityEngine;

public class Timer
{
    public event Action TimeFinished;

    public float maxTime;
    public float timeRemaining;
    public bool timerIsRunning = false;

    public Timer(float maxTime)
    {
        SetMaxTime(maxTime);
        ResetTimer();
    }

    public void SetMaxTime(float maxTime)
    {
        this.maxTime = maxTime;
    }

    public void Start()
    {
        timerIsRunning = true;
    }

    public void Stop()
    {
        timeRemaining = 0;
        timerIsRunning = false;
    }

    public void ResetTimer()
    {
        timeRemaining = maxTime;
    }

    public void Tick(float time)
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= time;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;

                TimeFinished?.Invoke();
            }
        }
    }

    public string GetTimeText()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
