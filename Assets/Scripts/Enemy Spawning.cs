using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Drag your enemy prefab here in the Inspector
    public Transform spawnPoint;    // Optional: where the enemy will spawn (you can leave empty to spawn in a random location)
    public float spawnInterval = 5f; // Time between spawns
    public List<GameObject> prefabShapes; // List of prefab shapes to randomly spawn
    public int numShapesToSpawn = 5; // Number of shapes to spawn
    public GameObject endPoint;
    private void Start()
    {
        // Start a repeating method to spawn enemies at the specified interval
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition;

        if (spawnPoint != null)
        {
            spawnPosition = spawnPoint.position; // Spawn at a specified point
        }
        else
        {
            // Spawn at a random position within a range if spawnPoint is not set
            spawnPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        }

        SpawnShapes();

    }

    private void SpawnShapes()
    {


        // Randomly select a prefab from the list
        GameObject prefab = prefabShapes[Random.Range(0, prefabShapes.Count)];

        GameObject gameObject = Instantiate(prefab, spawnPoint);

        Translation Script = gameObject.GetComponent<Translation>();

        Script.Square = endPoint;


        Debug.Log("shit");



    }
}
















