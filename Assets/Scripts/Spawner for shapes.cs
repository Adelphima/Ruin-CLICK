using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabShapes; // List of prefab shapes to randomly spawn
    public int numShapesToSpawn = 5; // Number of shapes to spawn
    public float spawnRadius = 5f; // Radius around the spawner for random spawn locations

    private List<GameObject> spawnedShapes = new List<GameObject>(); // List to track spawned shapes
    private int shapesCollected = 0; // Counter for collected shapes

    void Start()
    {
        SpawnShapes();
    }

    private void SpawnShapes()
    {
        for (int i = 0; i < numShapesToSpawn; i++)
        {
            // Randomly select a prefab from the list
            GameObject prefab = prefabShapes[Random.Range(0, prefabShapes.Count)];

            // Generate a random position within a radius around the spawner
            Vector3 spawnPosition = transform.position + (Random.insideUnitSphere * spawnRadius);
            spawnPosition.y = 0; // Ensure it's on the ground (optional)

            // Spawn the shape and store it in the list
            GameObject shapeInstance = Instantiate(prefab, spawnPosition, Quaternion.identity);
            spawnedShapes.Add(shapeInstance);

            // Attach this spawner as a reference to the shape's script
            Shapedirectiondetection shapeScript = shapeInstance.GetComponent<Shapedirectiondetection>();
            if (shapeScript != null)
            {
                shapeScript.SetSpawner(this);
            }
        }
    }

    // This function is called when a shape is collected
    public void OnShapeCollected()
    {
        shapesCollected++;

        // Check if all shapes have been collected
        if (shapesCollected >= numShapesToSpawn)
        {
            Debug.Log("Ruin completed! All shapes collected.");
            // Trigger any additional actions for completing the ruin
            // e.g., instantiate a new ruin object, play sound, etc.
        }
    }
}
