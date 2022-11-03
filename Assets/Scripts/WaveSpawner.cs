using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> enemies;
    public List<GameObject> currentEnemies;
    public int wave = 1;
    public int enemyTypes = 1;


    private void Start()
    {
        SpawnWave();
    }
    public void SpawnWave()
    {

        int enemiesToSpawn = (int)(wave * 1.3);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Invoke(methodName: "SpawnEnemy", Random.Range(0f, 2.0f));
        }
        if (wave % 2 == 0)
        {
            enemyTypes++;
            enemyTypes = Mathf.Clamp(enemyTypes, 0, 3);
        }
        GameManager.Instance.SetWaveNr(wave);
        wave++;
    }

    void SpawnEnemy()
    {
        //Choose randomly between current enemies
        int index = (int)Random.Range(0, enemyTypes);
        Debug.Log(index);
        currentEnemies.Add(Instantiate(enemies[index], spawnPoints[Random.Range(0, spawnPoints.Count)]));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnWave();
        }
    }
    public void RemoveEnemy(GameObject enemy)
    {
        if(currentEnemies.Contains(enemy))
            currentEnemies.Remove(enemy);

        if(currentEnemies.Count == 0)
        {
            Invoke(nameof(SpawnWave), 1f);
        }
    }
}
