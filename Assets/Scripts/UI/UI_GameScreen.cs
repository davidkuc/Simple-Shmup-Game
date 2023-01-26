using Zenject;

public class UI_GameScreen : UI_Container
{
    GameManager gameManager;

    [Inject]
    public void Setup(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    private void OnEnable()
    {
        gameManager.GameRunStarted += EnableCanvas;
        gameManager.GameRunEnded += DisableCanvas;
    }

    private void OnDisable()
    {
        gameManager.GameRunStarted -= EnableCanvas;
        gameManager.GameRunEnded -= DisableCanvas;
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
