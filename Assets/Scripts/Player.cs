using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    PlayerData_SO playerData_SO;

    DataManager dataManager;
    InputManager inputManager;

    PlayerShooting shooting;
    PlayerMovement movement;

    [Inject]
    public void Setup(DataManager dataManager, InputManager inputManager)
    {
        this.dataManager = dataManager;
        this.inputManager = inputManager;
    }

    private void Awake()
    {
        shooting = GetComponent<PlayerShooting>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        //playerData_SO = dataManager.PlayerData_SO;
    }

    private void OnEnable()
    {
        inputManager.ShootButtonPressed += Shoot;
        inputManager.UpButtonPressed += MoveUp;
        inputManager.DownButtonPressed += MoveDown;
    }

    private void OnDisable()
    {
        inputManager.ShootButtonPressed -= Shoot;
        inputManager.UpButtonPressed -= MoveUp;
        inputManager.DownButtonPressed -= MoveDown;
    }

    private void MoveDown()
    {
        //Debug.Log("Player Move Down!");
        movement.MoveDown();
    }

    private void MoveUp()
    {
        //Debug.Log("Player Move Up!");
        movement.MoveUp();
    }

    private void Shoot()
    {
        //Debug.Log("Player Shoot!");
    }
}
