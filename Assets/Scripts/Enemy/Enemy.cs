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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.transform.GetComponent<Player>();

        if (player)
        {
            DamagePlayer(player);
        }
    }

    private void DamagePlayer(Player player)
    {
        player.TakeDamage(enemyData_SO.DMG);
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

    public void ResetStats()
    {
        hpSystem.ResetHP();
    }

    [ContextMenu("Die")]
    private void Die()
    {
        EnemyDied?.Invoke(this);
    }

    public class Pool : MonoMemoryPool<Enemy>
    {

    }
}
