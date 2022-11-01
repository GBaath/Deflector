using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> enemies;
    List<GameObject> currentEnemies;
    public int wave = 1;
    public int enemyTypes = 1;


    public void SpawnWave()
    {
        int enemiesToSpawn = wave * 3;
        for (int i = 0; i > enemiesToSpawn; i++)
        {
            SpawnEnemy(0);
        }
    }

    void SpawnEnemy(int index)
    {
        currentEnemies.Add(Instantiate(enemies[index], spawnPoints[Random.Range(0, spawnPoints.Count)]));
    }
}
