using System;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    public event Action GameRunStarted;
    public event Action GameRunEnded;

    DataManager dataManager;
    InputManager inputManager;

    PointSystem pointSystem;

    bool isGameRunActive;

    public bool IsGameRunActive => isGameRunActive;

    [Inject]
    public void Setup(DataManager dataManager, InputManager inputManager)
    {
        this.dataManager = dataManager;
        this.inputManager = inputManager;
    }

    private void Awake()
    {
        pointSystem = new PointSystem();
    }

    private void Start()
    {
        var loadedData = dataManager.LoadData();
        pointSystem.LoadScore(loadedData);
    }

    private void OnEnable()
    {
        inputManager.AnyButtonPressed += StartGame;
        Enemy.EnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        inputManager.AnyButtonPressed -= StartGame;
        Enemy.EnemyDied -= OnEnemyDied;
    }

    private void OnApplicationQuit()
    {
        dataManager.UpdateData(pointSystem.GetNewPlayerScore());
        dataManager.SaveData();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        AddPointsToCurrentScore(enemy.EnemyData_SO.PointsForDeath);
    }

    public void AddPointsToCurrentScore(int points)
    {
        pointSystem.AddPointsToCurrentScore(points);
        pointSystem.SetLatestScoreToCurrentScore();
        dataManager.UpdateData(pointSystem.GetNewPlayerScore());
    }

    public void StartGame()
    {
        if (IsGameRunActive)
            return;

        isGameRunActive = true;
        GameRunStarted?.Invoke();
    }

    public void EndGame()
    {
        isGameRunActive = false;
        pointSystem.ResetCurrentScore();
        dataManager.UpdateData(pointSystem.GetNewPlayerScore());
        dataManager.SaveData();
        GameRunEnded?.Invoke();
    }
}
