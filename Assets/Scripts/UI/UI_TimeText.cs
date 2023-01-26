using System;
using TMPro;
using UnityEngine;
using Zenject;

public class UI_TimeText : MonoBehaviour
{
    GameManager gameManager;

    TMP_Text text;
    Timer timer;

    [Inject]
    public void Setup(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    private void Awake()
    {
        text = transform.Find("text").GetComponent<TMP_Text>();
        timer = new Timer(1800);
    }

    private void Update()
    {
        if (timer.timerIsRunning)
        {
            Debug.Log("Timer running!");
            timer.Tick(Time.deltaTime);
            text.text = timer.GetTimeText();
        }
    }

    private void OnEnable()
    {
        gameManager.GameRunStarted += StartTimer;
        gameManager.GameRunEnded += EndTimer;
    }

    private void OnDisable()
    {
        gameManager.GameRunStarted -= StartTimer;
        gameManager.GameRunEnded -= EndTimer;
    }

    private void EndTimer()
    {
        timer.Stop();
    }

    public void StartTimer()
    {
        timer.Start();
    }
}
