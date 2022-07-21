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
    private float rapidNumber = 0;
    public GameObject asteroidFieldText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroid());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnAsteroid()
    {
        int animalIndex = Random.Range(0, asteroidPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        GameObject asteroid = Instantiate(asteroidPrefabs[animalIndex], spawnPos, asteroidPrefabs[animalIndex].transform.rotation);
        asteroid.GetComponent<AstroidScripts>().speed = 5000;
        if (rapidNumber == 0)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 3f));
            asteroidFieldText.SetActive(false);
        }
        if(rapidNumber != 0)
        {
            yield return new WaitForSeconds(Random.Range(.2f, .5f));
            rapidNumber -= 1;
            asteroidFieldText.SetActive(true);
        }
        float chance = Random.Range(1, 20);
        if(Random.Range(1,20) == chance)
        {
            rapidNumber = Random.Range(15, 25);
        }
        StartCoroutine(SpawnAsteroid());
    }
}
