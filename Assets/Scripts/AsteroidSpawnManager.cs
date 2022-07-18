using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    private float spawnRangeX = 10;
    private float spawnRangeY = 10;
    private float spawnPosZ = 50;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAsteroid", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAsteroid()
    {
        int animalIndex = Random.Range(0, asteroidPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(asteroidPrefabs[animalIndex], spawnPos, asteroidPrefabs[animalIndex].transform.rotation);
    }
}
