using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    public static event Action<Bullet> BulletHit;

    [SerializeField] float bulletSpeed = 0.3f;
    [SerializeField] int damage = 1;
    WaitForSecondsRealtime waitUntilDespawnTime;
    bool isBulletShot;
    bool didBulletHit;

    private void Awake()
    {
        waitUntilDespawnTime = new WaitForSecondsRealtime(3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<Enemy>();

        if (enemy)
        {
            DealDamage(enemy);
            Despawn();
            return;
        }
    }

    private void Despawn()
    {
        isBulletShot = false;
        didBulletHit = false;
        BulletHit?.Invoke(this);
    }

    private IEnumerator DespawnWithDelay()
    {
        yield return waitUntilDespawnTime;

        if (!didBulletHit)
        BulletHit?.Invoke(this);
    }

    private void Update()
    {
        if (isBulletShot)
        {
            transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        }
    }

    public void Shoot()
    {
        isBulletShot = true;
        StartCoroutine(DespawnWithDelay());
    }

    private void DealDamage(Enemy enemy)
    {
        enemy.TakeDamage(damage);
        didBulletHit = true;
    }

    public class Pool : MonoMemoryPool<Bullet>
    {

    }
}
