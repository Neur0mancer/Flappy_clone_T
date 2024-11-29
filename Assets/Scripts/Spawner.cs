using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float minSpawnHeight = -1f;
    [SerializeField] private float maxSpawnHeight = 1f;

    private void OnEnable()
    {
        StartSpawning();
    }

    private void OnDisable()
    {
        StopSpawning();
    }

    private void SpawnPipe()
    {
        GameObject pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        pipe.transform.position += Vector3.up * Random.Range(minSpawnHeight, maxSpawnHeight);
    }

    private void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnPipe), spawnInterval, spawnInterval);
    }

    private void StopSpawning()
    {
        CancelInvoke(nameof(SpawnPipe));
    }
}

