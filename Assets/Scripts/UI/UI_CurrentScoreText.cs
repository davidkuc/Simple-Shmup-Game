using TMPro;
using UnityEngine;
using Zenject;

public class UI_CurrentScoreText : MonoBehaviour
{
    GameManager gameManager;

    TMP_Text text;

    [Inject]
    public void Setup(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    private void Awake()
    {
        text = transform.Find("text").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        text.text = "0";
    }

    private void OnEnable()
    {
        gameManager.CurrentScoreUpdated += UpdateText;
    }

    private void OnDisable()
    {
        gameManager.CurrentScoreUpdated -= UpdateText;
    }

    public void UpdateText(int currentScore)
    {
        text.text = currentScore.ToString();
    }
}
