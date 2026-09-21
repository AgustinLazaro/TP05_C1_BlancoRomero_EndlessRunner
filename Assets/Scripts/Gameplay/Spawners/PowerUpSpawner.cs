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
        NextInterval();
    }

    private void Update()
    {
        if (GameManager.Instance.BoostActive())
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= currentSpawnInterval)
        {
            SpawnPowerUp();
            timer = 0f;
            NextInterval();
        }
    }


    private void SpawnPowerUp()
    {
        powerUpPool.Get(transform.position);
    }

    private void NextInterval()
    {
        currentSpawnInterval = Random.Range(minSpawnTime, maxSpawnTime);
    }
}

