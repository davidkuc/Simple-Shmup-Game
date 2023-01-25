using TMPro;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    DataManager dataManager;
    InputManager inputManager;

    bool isGameRunActive;

    [Inject]
    public void Setup(DataManager dataManager, InputManager inputManager)
    {
        this.dataManager = dataManager;
        this.inputManager = inputManager;
    }

    private void OnEnable()
    {
        inputManager.AnyButtonPressed += StartGame;
    }

    private void OnDisable()
    {
        inputManager.AnyButtonPressed -= StartGame;
    }

    public void StartGame()
    {
        if (isGameRunActive)
            return;

        isGameRunActive = true;
        // spawn player
        // start spawning enemies
    }

    public void EndGame()
    {
        // end game
        // update data
    }
}
