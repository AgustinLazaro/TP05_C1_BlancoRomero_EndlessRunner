using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("Pool Reference")]
    [SerializeField] private ObjectPool powerUpPool;

    [Header("Spawn Rate")]
    [SerializeField] private float minSpawnTime = 5f;
    [SerializeField] private float maxSpawnTime = 9f;

    private float timer;
    private float currentSpawnInterval;

    private void Start()
    {
        SetNextInterval();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= currentSpawnInterval)
        {
            SpawnPowerUp();
            timer = 0f;
            SetNextInterval();
        }
    }

    private void SpawnPowerUp()
    {
        powerUpPool.Get(transform.position);
    }

    private void SetNextInterval()
    {
        currentSpawnInterval = Random.Range(minSpawnTime, maxSpawnTime);
    }
}