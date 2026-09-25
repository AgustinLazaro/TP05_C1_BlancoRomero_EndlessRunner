using UnityEngine;

public class LoopingGround : MonoBehaviour
{
    [SerializeField] private float leftLimit = -30f;
    [SerializeField] private float resetDistance = 60f;

    private void Update()
    {
        float currentSpeed = GameManager.Instance.GetCurrentSpeed();

        transform.position += Vector3.left * (currentSpeed * Time.deltaTime);

        if (transform.position.x <= leftLimit)
        {
            transform.position += Vector3.right * resetDistance;
        }
    }
}