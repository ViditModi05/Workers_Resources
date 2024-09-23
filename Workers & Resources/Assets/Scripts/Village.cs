using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject worker;
    [SerializeField] public Transform spawnPoint;   

    [Header("Settings")]
    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private int numberOfWorkers;
    private float nextSpawnTime;



    private void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawn;
            Instantiate(worker, spawnPoint.position, Quaternion.identity);
            numberOfWorkers--;
        }
        if(numberOfWorkers <= 0 )
        {
            Destroy(gameObject);
        }
    }

}
