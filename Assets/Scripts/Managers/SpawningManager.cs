using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static Enemy;

public class SpawningManager : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns;

    public static Vector2 despawnPosition = new Vector2(-4, -8);

    Enemy.Pool enemyPool;
    Player player;
    PlayerSpawningPoint playerSpawningPoint;
    SpawningPoint[] spawningPoints;

    Coroutine spawningCoroutineObject;

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
        player.transform.position = playerSpawningPoint.transform.position;
    }

    [ContextMenu("Start Spawning Enemies")]
    public void StartSpawningEnemies()
    {
        spawningCoroutineObject = StartCoroutine(SpawningCoroutine());
    }

    [ContextMenu("Stop Spawning Enemies")]
    public void StopSpawningEnemies()
    {
        StopCoroutine(spawningCoroutineObject);
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
        enemy.SetSpawningManager(this);
        enemy.transform.position = spawningPoints[GetRandomIndex()].transform.position;
        enemy.StartMoving();
    }

    public void DespawnEnemy(Enemy enemy)
    {
        enemy.UnsetSpawningManager();
        enemy.transform.position = despawnPosition;
        enemyPool.Despawn(enemy);
        enemy.StopMoving();
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, 5);
    }
}
