using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Refernces")]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;

    [Header("Settings")]
    [SerializeField] private float timeBetweenSpawn;
    private float nextSpawnTime;



    private void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawn;
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }
    }

}
