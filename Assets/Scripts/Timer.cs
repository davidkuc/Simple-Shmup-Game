using UnityEngine;

public class Timer
{
    public float maxTime = 10;
    public float timeRemaining;
    public bool timerIsRunning = false;

    public Timer(float maxTime)
    {
        timerIsRunning = true;
        SetMaxTime(maxTime);
        timeRemaining = maxTime;
    }

    public void SetMaxTime(float maxTime)
    {
        this.maxTime -= maxTime;
    }

    public void Start()
    {
        timeRemaining = maxTime;
        timerIsRunning = true;
    }

    public void Stop()
    {
        timeRemaining = 0;
        timerIsRunning = false;
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
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
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
