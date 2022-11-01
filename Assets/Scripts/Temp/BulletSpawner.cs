using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float spawnDelay = 1;
    [SerializeField] private GameObject bullet;

    void Start()
    {
        Invoke(nameof(SpawnBullet), spawnDelay);
    }
    void SpawnBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        Invoke(nameof(SpawnBullet), spawnDelay);
    }
}
