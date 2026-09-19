using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Pool Reference")]
    [SerializeField] private ObjectPool obstaclePool;

    [Header("Spawn Rate (Random Interval)")]
    [SerializeField] private float minSpawnTime = 1.5f;
    [SerializeField] private float maxSpawnTime = 3f;

    private float timer;
    private float currentSpawnInterval;

    private void Start()
    {
        SpawnInterval();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= currentSpawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
            SpawnInterval();
        }
    }

    private void SpawnObstacle()
    {
        obstaclePool.Get(transform.position);
    }

    private void SpawnInterval()
    {
        currentSpawnInterval = Random.Range(minSpawnTime, maxSpawnTime);
    }
}