using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
    }
}