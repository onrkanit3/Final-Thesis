using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int bulletPerSecond = 1000;
    [SerializeField] private float speed = 5;
    [SerializeField] private bool useObjectPool;
    private float lastSpawnTime;
    private ObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(CreatePooledObject, OnTakeFromPool, OnReturnToPool, OnDestroyObject, false,
            200, 100_000);
    }

    private Bullet CreatePooledObject()
    {
        var instance = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
        instance.OnDeactivated += ReturnObjectToPool;
        instance.transform.SetParent(transform, true);
        instance.gameObject.SetActive(false);

        return instance;
    }

    private void OnTakeFromPool(Bullet instance)
    {
        instance.gameObject.SetActive(true);
        SpawnBullet(instance);
    }
    
    private void ReturnObjectToPool(Bullet instance)
    {
        bulletPool.Release(instance);
    }

    private void OnReturnToPool(Bullet instance)
    {
        instance.gameObject.SetActive(false);
    }
    
    private void OnDestroyObject(Bullet instance)
    {
        Destroy(instance.gameObject);
    }

    private void Update()
    {
        var delay = 1f / bulletPerSecond;
        if (lastSpawnTime + delay < Time.time)
        {
            var bulletsToSpawnInFrame = Mathf.CeilToInt(Time.deltaTime / delay);
            while (bulletsToSpawnInFrame > 0)
            {
                if (!useObjectPool)
                {
                    var instance = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
                    instance.transform.SetParent(transform,true);
                    SpawnBullet(instance);
                }

                else
                {
                    bulletPool.Get();
                }

                bulletsToSpawnInFrame--;
            }

            lastSpawnTime = Time.time;
        }
    }

    private void SpawnBullet(Bullet instance)
    {
        var spawnPos = new Vector3(Random.Range(-5, 5), 0, 0);
        instance.transform.position = spawnPos;
        instance.Shoot(spawnPos, instance.transform.forward,speed);
    }
}
