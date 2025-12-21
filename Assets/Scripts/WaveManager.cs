using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public GameObject waypoint;


    public float timeBetweenEnemies = 1f;
    public int enemiesInWave = 5;

    void Start()
    {
        StartCoroutine(SpawnWave());
    
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesInWave; i++)
        {
            GameObject enemy= Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().SetWaypoint(waypoint);
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }
}

