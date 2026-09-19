using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pool.ReturnToPool(collision.gameObject);
    }
}