using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> enemies;
    [SerializeField]List<GameObject> currentEnemies;
    public int wave = 1;
    public int enemyTypes = 1;


    public void SpawnWave()
    {
        if (wave % 3 == 0)
            enemyTypes++;

        int enemiesToSpawn = wave * 3;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Invoke(methodName: "SpawnEnemy", Random.Range(0f, 5.0f));
        }
        wave++;
    }

    void SpawnEnemy()
    {
        //Choose randomly between current enemies
        int index = (int)Random.Range(0, enemyTypes);
        currentEnemies.Add(Instantiate(enemies[index], spawnPoints[Random.Range(0, spawnPoints.Count)]));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnWave();
        }
    }
}
