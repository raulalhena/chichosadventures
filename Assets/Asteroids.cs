using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;


    void Start()
    {
        InvokeRepeating("SpawnAsteroids", 0.25f, 0.25f);

    }

    void Update()
    {
    }

    void SpawnAsteroids()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
    }
}
