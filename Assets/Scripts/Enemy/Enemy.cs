using System;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> EnemyDied;

    [SerializeField] EnemyData_SO enemyData_SO;

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
        EnemyDied?.Invoke(this);
    }

    public void ResetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public class Pool : MonoMemoryPool<Enemy>
    {

    }
}
