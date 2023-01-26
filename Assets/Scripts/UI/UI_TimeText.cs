using System;
using TMPro;
using UnityEngine;
using Zenject;

public class UI_TimeText : UI_Container
{
    GameManager gameManager;

    TMP_Text text;
    Timer timer;

    [Inject]
    public void Setup(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    protected override void Awake()
    {
        base.Awake();
        text = Canvas.transform.Find("text").GetComponent<TMP_Text>();
        timer = new Timer(30);
    }

    private void Update()
    {
        if (timer.timerIsRunning)
        {
            timer.Tick(Time.deltaTime);
            text.text = timer.GetTimeText();
        }
    }

    private void OnEnable()
    {
        gameManager.GameRunStarted += OnGameRunStarted;
        gameManager.GameRunEnded += EndTimer;
        timer.TimeFinished += OnTimeFinished;
    }

    private void OnDisable()
    {
        gameManager.GameRunStarted -= OnGameRunStarted;
        gameManager.GameRunEnded -= EndTimer;
        timer.TimeFinished -= OnTimeFinished;
    }

    private void OnGameRunStarted()
    {
        ToggleCanvas(true);
        StartTimer(gameManager.GameRunTime);
    }

    private void OnTimeFinished()
    {
        ToggleCanvas(false);
        gameManager.EndGame();
    }

    public void EndTimer()
    {
        timer.Stop();
    }

    public void StartTimer(float gameRunTime)
    {
        timer.SetMaxTime(gameRunTime);
        timer.ResetTimer();
        timer.Start();
    }

    internal void SetGameRunTimer(float gameRunTime)
    {
        throw new NotImplementedException();
    }
}
