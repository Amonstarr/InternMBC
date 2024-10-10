using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // Array untuk beberapa prefab musuh
    public Transform[] spawnPoints;
    public int numberOfEnemies = 5;
    public float spawnDelay = 2f;  // Waktu jeda antar spawn

    void Start()
    {
        // Mulai Coroutine untuk spawn musuh dengan jeda waktu
        StartCoroutine(SpawnEnemiesWithDelay());
    }

    IEnumerator SpawnEnemiesWithDelay()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Pilih spawn point secara acak
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Pilih enemyPrefab secara acak dari array
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Instantiate musuh
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Tunggu waktu jeda sebelum spawn musuh berikutnya
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
