using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class UI_BestScoreText : MonoBehaviour
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
        text.text = dataManager.PlayerData_SO.BestScore.ToString();
    }
}