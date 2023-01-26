using System;
using UnityEngine;
using Zenject;

public class UI_PlayerHP : MonoBehaviour
{
    UI_Heart[] hearts;
    Player player;

    int currentIndex;

    [Inject]
    public void Setup(Player player)
    {
        this.player = player;
    }

    private void Awake()
    {
        hearts = GetComponentsInChildren<UI_Heart>();
    }

    private void Start()
    {
        ResetIndex();
    }

    private void ResetIndex()
    {
        currentIndex = hearts.Length - 1;
    }

    private void OnEnable()
    {
        player.PlayerDamaged += UpdateHearts();
        player.PlayerReset += ResetHearts();
    }

    private void OnDisable()
    {
        player.PlayerDamaged -= UpdateHearts();
        player.PlayerReset -= ResetHearts();
    }

    private Action ResetHearts()
    {
        return () =>
        {
            foreach (var item in hearts)
            {
                item.gameObject.SetActive(true);
            }

            ResetIndex();
        };
    }

    private Action UpdateHearts()
    {
        return () =>
        {
            hearts[currentIndex].gameObject.SetActive(false);
            currentIndex--;
        };
    }
}
