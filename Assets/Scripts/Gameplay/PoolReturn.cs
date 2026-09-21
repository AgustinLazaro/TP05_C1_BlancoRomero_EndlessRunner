using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    [SerializeField] private ObjectPool obstaclePool;
    [SerializeField] private ObjectPool powerUpPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PowerUpItem>(out _))
        {
            powerUpPool.ReturnToPool(collision.gameObject);
            return;
        }

        obstaclePool.ReturnToPool(collision.gameObject);
    }
}