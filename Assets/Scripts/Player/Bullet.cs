using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    public static event Action<Bullet> BulletHit;

    [SerializeField] float bulletSpeed = 0.3f;
    [SerializeField] int damage = 1;
    bool isBulletShot;

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
        Invoke(nameof(Despawn), 3);
    }

    private void DealDamage(Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }

    public class Pool : MonoMemoryPool<Bullet>
    {

    }
}
