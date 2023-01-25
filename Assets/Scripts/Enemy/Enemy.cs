using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyData_SO enemyData_SO;

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
        hpSystem.SetMaxHP(enemyData_SO.MaxHP);
    }

    public void StartMoving()
    {
        movement.StartMoving();
    }

    public void StopMoving()
    {
        movement.StopMoving();
    }

    public void TakeDamage(int damage)
    {
        hpSystem.TakeDamage(damage);

        if (hpSystem.IsDead) Die();
    }

    private void Die()
    {
        // Pooling stuff, should go back where he came from
    }

    public void ResetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public class Pool : MonoMemoryPool<Enemy>
    {
        //protected override void Reinitialize(Vector2 resetPosition, Enemy item)
        //{
        //    base.Reinitialize(resetPosition, item);
        //    item.ResetPosition(resetPosition);
        //}
    }
}
