using System;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerData_SO playerData_SO;

    DataManager dataManager;
    InputManager inputManager;

    PlayerShooting shooting;
    PlayerMovement movement;
    HPSystem hpSystem;

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
        hpSystem = new HPSystem();
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

    private void TakeDamage(int damage)
    {
        hpSystem.TakeDamage(damage);

        if (hpSystem.IsDead) Die();
    }

    private void Die()
    {
        // end game
    }
}
