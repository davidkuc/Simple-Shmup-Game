using System;
using UnityEngine;
using Zenject;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyData_SO enemyData_SO;

    SpawningManager spawningManager;

    EnemyMovement movement;
    HPSystem hpSystem;

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

    [ContextMenu("Die")]
    private void Die()
    {
        spawningManager.DespawnEnemy(this);
    }

    public void ResetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void SetManager(SpawningManager spawningManager)
    {
        this.spawningManager = spawningManager;
    }

    public void UnSetManager()
    {
        this.spawningManager = null;
    }

    public class Pool : MonoMemoryPool<Enemy>
    {
        //protected override void Reinitialize(SpawningManager spawningManager, Enemy item)
        //{
        //    base.Reinitialize(resetPosition, item);
        //    item.ResetPosition(resetPosition);
        //}
    }
}
