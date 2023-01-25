using System.Data;
using TMPro;
using UnityEngine;
using Zenject;

public class UI_LatestScoreText : MonoBehaviour
{
    DataManager dataManager;

    TMP_Text text;

    [Inject]
    public void Setup(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    private void Awake()
    {
        text = transform.Find("text").GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        dataManager.DataUpdated += UpdateText;
    }

    private void OnDisable()
    {
        dataManager.DataUpdated += UpdateText;
    }

    public void UpdateText()
    {
        text.text = dataManager.PlayerData_SO.LatestScore.ToString();
    }
}
