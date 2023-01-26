using System;
using UnityEngine;
using Zenject;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public event Action GameRunStarted;
    public event Action GameRunEnded;
    public event Action<int> CurrentScoreUpdated;

    [SerializeField] float gameRunTime;

    DataManager dataManager;
    InputManager inputManager;

    PointSystem pointSystem;

    bool isGameRunActive;

    public bool IsGameRunActive => isGameRunActive;

    public float GameRunTime => gameRunTime; 

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
        dataManager.UpdateData(pointSystem.GetScoreData());
        dataManager.SaveData();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        AddPointsToCurrentScore(enemy.EnemyData_SO.PointsForDeath);
    }

    public void AddPointsToCurrentScore(int points)
    {
        pointSystem.AddPointsToCurrentScore(points);
        dataManager.UpdateData(pointSystem.GetScoreData());
        CurrentScoreUpdated?.Invoke(pointSystem.GetCurrentScore());
    }

    [ContextMenu("Start Game")]
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
        CurrentScoreUpdated?.Invoke(pointSystem.GetCurrentScore());

        dataManager.UpdateData(pointSystem.GetScoreData());
        dataManager.SaveData();

        GameRunEnded?.Invoke();
    }
}
