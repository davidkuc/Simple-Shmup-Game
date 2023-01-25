using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static Enemy;

public class SpawningManager : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns;

    Enemy.Pool enemyPool;
    Player player;
    PlayerSpawningPoint playerSpawningPoint;
    SpawningPoint[] spawningPoints;

    Vector2 despawnPosition = new Vector2(-4, -8);

    [Inject]
    public void Setup(Enemy.Pool enemyPool, Player player)
    {
        this.enemyPool = enemyPool;
        this.player = player;
    }

    private void Awake()
    {
        spawningPoints = GetComponentsInChildren<SpawningPoint>();
        playerSpawningPoint = GetComponentInChildren<PlayerSpawningPoint>();
    }

    [ContextMenu("Spawn Player")]
    public void SpawnPlayer()
    {
        //player.ResetPosition(playerSpawningPoint.transform.position);
        player.transform.position = playerSpawningPoint.transform.position;
    }

    public void StartSpawningEnemies()
    {
        StartCoroutine(SpawningCoroutine());
    }

    public void StopSpawningEnemies()
    {
        StopCoroutine(SpawningCoroutine());
    }

    private IEnumerator SpawningCoroutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(timeBetweenSpawns);

            SpawnEnemy();
        }
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
