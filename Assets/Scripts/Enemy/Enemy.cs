using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    DataManager dataManager;

    EnemyMovement movement;
    HPSystem hpSystem;

    [Inject]
    public void Setup(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        hpSystem = new HPSystem();
    }

    private void Start()
    {
        //hpSystem.SetMaxHP(dataManager.EnemyData_SO.MaxHP);
    }

    public void StartMoving()
    {

    }

    public void StopMoving()
    {

    }

    public void TakeDamage(int dmg)
    {

    }

    private void Die()
    {

    }

    public void ResetPosition(Vector2 position)
    {
        transform.position = position;
    }
}
