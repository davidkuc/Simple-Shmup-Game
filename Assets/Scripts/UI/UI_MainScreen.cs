using System;
using Zenject;

public class UI_MainScreen : UI_Container
{
    GameManager gameManager;

    [Inject]
    public void Setup(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    private void OnEnable()
    {
        gameManager.GameRunStarted += DisableCanvas;
        gameManager.GameRunEnded += EnableCanvas;
    }

    private void OnDisable()
    {
        gameManager.GameRunStarted -= DisableCanvas;
        gameManager.GameRunEnded -= EnableCanvas;
    }

    private void EnableCanvas()
    {
        ToggleCanvas(true);
    }

    private void DisableCanvas()
    {
        ToggleCanvas(false);
    }
}
