using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static Enemy;

public class SpawningManager : MonoBehaviour
{
    Enemy.Pool enemyPool;
    SpawningPoint[] spawningPoints;

    Vector2 despawnPosition = new Vector2(-4, -8);

    [Inject]
    public void Setup(Enemy.Pool enemyPool)
    {
        this.enemyPool = enemyPool;
    }

    private void Awake()
    {
        spawningPoints = GetComponentsInChildren<SpawningPoint>();     
    }

    [ContextMenu("Spawn Enemy")]
    public void SpawnEnemy()
    {
        var enemy = enemyPool.Spawn();
        enemy.SetManager(this);
        enemy.transform.position = spawningPoints[GetRandomIndex()].transform.position;
        enemy.StartMoving();
    }

    public void DespawnEnemy(Enemy enemy)
    {
        enemy.UnSetManager();
        enemy.transform.position = despawnPosition;
        enemyPool.Despawn(enemy);
        enemy.StopMoving();
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, 5);
    }
}
