using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private void Update()
    {
        float currentSpeed = GameManager.Instance.GetCurrentSpeed();
        transform.position += Vector3.left * (currentSpeed * Time.deltaTime);
    }
}