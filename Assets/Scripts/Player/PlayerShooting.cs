using UnityEngine;
using Zenject;

public class PlayerShooting : MonoBehaviour
{
    Bullet.Pool bulletPool;

    [Inject]
    public void Setup(Bullet.Pool bulletPool, Player player)
    {
        this.bulletPool = bulletPool;
    }

    private void OnEnable()
    {
        Bullet.BulletHit += DespawnBullet;   
    }

    private void OnDisable()
    {
        Bullet.BulletHit -= DespawnBullet;
    }

    private void DespawnBullet(Bullet obj)
    {
        bulletPool.Despawn(obj);
    }

    public void Shoot()
    {
        var bullet = bulletPool.Spawn();
        bullet.transform.position = transform.position;
        bullet.Shoot();
    }
}
