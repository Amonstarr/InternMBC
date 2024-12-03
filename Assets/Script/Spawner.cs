using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public int numberOfEnemies = 5;
    public float spawnDelay = 2f;

    void Start()
    {
        StartCoroutine(SpawnEnemiesWithDelay());
    }

    IEnumerator SpawnEnemiesWithDelay()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
