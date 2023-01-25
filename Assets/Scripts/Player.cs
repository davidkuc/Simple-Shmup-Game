using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    PlayerData_SO playerData_SO;

    DataManager dataManager;
    InputManager inputManager;

    //ShootComponent shooter;
   // MovementComponent movement;

    [Inject]
    public void Setup(DataManager dataManager, InputManager inputManager)
    {
        this.dataManager = dataManager;
        this.inputManager = inputManager;
    }

    private void Start()
    {
        playerData_SO = dataManager.PlayerData_SO;
    }

    private void OnEnable()
    {
        //inputManager.
    }
}
