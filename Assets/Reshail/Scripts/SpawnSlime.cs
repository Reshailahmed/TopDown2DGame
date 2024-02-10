using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlime : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f; // Time interval between spawns
    public float spawnRadius = 5f; // Radius around the spawner to spawn enemies
    private float timer = 0f;

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f; // Reset the timer
        }
    }

    private void SpawnEnemy()
    {
        // Generate a random position within the spawn radius
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 0f; // Ensure enemies spawn at the same height as the spawner

        // Instantiate the enemy prefab at the random position
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a wire sphere in the editor to visualize the spawn radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
