using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerData_SO playerData_SO;

    GameManager gameManager;
    DataManager dataManager;
    InputManager inputManager;
    SpawningManager spawningManager;

    PlayerShooting shooting;
    PlayerMovement movement;
    HPSystem hpSystem;

    [Inject]
    public void Setup(GameManager gameManager, DataManager dataManager, InputManager inputManager)
    {
        this.gameManager = gameManager;
        this.dataManager = dataManager;
        this.inputManager = inputManager;
    }

    private void Awake()
    {
        shooting = GetComponent<PlayerShooting>();
        movement = GetComponent<PlayerMovement>();
        hpSystem = new HPSystem();

        transform.position = SpawningManager.despawnPosition;
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
        if (!gameManager.IsGameRunActive)
            return;
        //Debug.Log("Player Move Down!");
        movement.MoveDown();
    }

    private void MoveUp()
    {
        if (!gameManager.IsGameRunActive)
            return;
        //Debug.Log("Player Move Up!");
        movement.MoveUp();
    }

    private void Shoot()
    {
        if (!gameManager.IsGameRunActive)
            return;
        //Debug.Log("Player Shoot!");
        shooting.Shoot();
    }

    public void TakeDamage(int damage)
    {
        hpSystem.TakeDamage(damage);

        if (hpSystem.IsDead) Die();
    }

    public void ResetStats()
    {
        hpSystem.ResetHP();
    }

    private void Die()
    {
        gameManager.EndGame();
    }
}
