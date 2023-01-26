using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public event Action DataUpdated;

    [SerializeField] PlayerData_SO playerData_SO;

    SaveSystem saveSystem;

    public PlayerData_SO PlayerData_SO => playerData_SO;

    private void Awake()
    {
        saveSystem = new SaveSystem();
    }

    public void SaveData()
    {
        Debug.Log("Saving Data");
        var playerDataStructure = CreateNewPlayerDataStructure();

        MapPlayer_SO_ToPlayerDataStructure(playerDataStructure);
        saveSystem.SavePlayer(playerDataStructure);
    }

    public PlayerDataStructure LoadData()
    {
        var playerDataStructure = saveSystem.LoadPlayer();
        if (playerDataStructure == null)
        {
            Debug.Log("Didnt find save file");
            SaveData();
            return CreateNewPlayerDataStructure();
        }
        MapPlayerDataStructureToPlayer_SO(playerDataStructure);

        DataUpdated?.Invoke();
        Debug.Log($"Loaded Data");

        return playerDataStructure;
    }

    private void MapPlayer_SO_ToPlayerDataStructure(PlayerDataStructure playerDataStructure)
    {
        playerDataStructure.BestScore = playerData_SO.BestScore;
        playerDataStructure.LatestScore = playerData_SO.LatestScore;
    }

    private void MapPlayerDataStructureToPlayer_SO(PlayerDataStructure playerDataStructure)
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

    public void UpdateData(PlayerDataStructure newPlayerDataStructure)
    {
        MapPlayerDataStructureToPlayer_SO(newPlayerDataStructure);
        DataUpdated?.Invoke();
    }

    [ContextMenu("Open Data Folder")]
    public void OpenDataFolder()
    {
        saveSystem.OpenPlayerDataFolder();
    }
}
