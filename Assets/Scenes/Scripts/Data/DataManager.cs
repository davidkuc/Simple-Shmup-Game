using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public event Action DataUpdated;

    SaveSystem saveSystem;

    PlayerData_SO playerData_SO;
    PlayerDataStructure playerDataStructure;

    public PlayerData_SO PlayerData_SO => playerData_SO;

    private void Awake()
    {
        saveSystem = new SaveSystem();
    }

    public void SaveData()
    {
        if (playerDataStructure == null)
        {
            Debug.Log("Creating new player data structure on SaveData()");
            playerDataStructure = CreateNewPlayerDataStructure();
        }

        MapPlayer_SO_ToPlayerDataStructure();
        saveSystem.SavePlayer(playerDataStructure);
    }

    public void LoadData()
    {
        if (playerDataStructure == null)
        {
            Debug.Log("Creating new player data structure on LoadData()");
            playerDataStructure = CreateNewPlayerDataStructure();
        }

        playerDataStructure = saveSystem.LoadPlayer();
        MapPlayerDataStructureToPlayer_SO();
    }

    private void MapPlayer_SO_ToPlayerDataStructure()
    {
        playerDataStructure.BestScore = playerData_SO.BestScore;
        playerDataStructure.LatestScore = playerData_SO.LatestScore;
    }

    private void MapPlayerDataStructureToPlayer_SO()
    {
        playerData_SO.BestScore = playerDataStructure.BestScore;
        playerData_SO.LatestScore = playerDataStructure.LatestScore;
    }

    private PlayerDataStructure CreateNewPlayerDataStructure()
    {
        var newPlayerData = new PlayerDataStructure();
        newPlayerData.BestScore = playerData_SO.BestScore;
        newPlayerData.LatestScore = playerData_SO.LatestScore;

        return newPlayerData;
    }
}
