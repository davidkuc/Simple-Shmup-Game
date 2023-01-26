using System;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> EnemyDied;

    [SerializeField] EnemyData_SO enemyData_SO;

    EnemyMovement movement;
    HPSystem hpSystem;
    bool isDespawning;


    public EnemyData_SO EnemyData_SO => enemyData_SO;

    public bool IsDespawning => isDespawning; 

    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        hpSystem = new HPSystem();
    }

    private void Start()
    {
        hpSystem.SetMaxHP(EnemyData_SO.MaxHP);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.transform.GetComponent<Player>();

        if (collision.transform.CompareTag(GameConstants.PlayerTag))
        {
            DamagePlayer(player);
            Die();
        }
        else if (collision.transform.CompareTag(GameConstants.EnemyCatcherTag))
        {
            Die();
        }
    }

    private void DamagePlayer(Player player)
    {
        player.TakeDamage(EnemyData_SO.DMG);
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
        isDespawning = false;
    }

    [ContextMenu("Die")]
    public void Die()
    {
        if (isDespawning)
            return;

        isDespawning = true;
        EnemyDied?.Invoke(this);
    }

    public class Pool : MonoMemoryPool<Enemy>
    {

    }
}
