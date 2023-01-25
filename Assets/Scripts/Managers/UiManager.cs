using UnityEngine;
using Zenject;

public class UiManager : MonoBehaviour
{
    GameManager gameManager;
    UI_MainScreen ui_MainScreen;
    UI_GameScreen ui_GameScreen;

    [Inject]
    public void Setup(GameManager gameManager, UI_MainScreen ui_MainScreen, UI_GameScreen ui_GameScreen)
    {
        this.gameManager = gameManager;
        this.ui_MainScreen = ui_MainScreen;
        this.ui_GameScreen = ui_GameScreen;
    }

    private void OnEnable()
    {
        gameManager.GameRunStarted += OnGameRunStarted;
        gameManager.GameRunEnded += OnGameRunEnded;
    }
    private void OnDisable()
    {
        gameManager.GameRunStarted -= OnGameRunStarted;
        gameManager.GameRunEnded -= OnGameRunEnded;
    }

    private void OnGameRunEnded()
    {
        ui_GameScreen.ToggleCanvas(false);
        ui_MainScreen.ToggleCanvas(true);
    }

    private void OnGameRunStarted()
    {
        ui_GameScreen.ToggleCanvas(true);
        ui_MainScreen.ToggleCanvas(false);
    }
}
