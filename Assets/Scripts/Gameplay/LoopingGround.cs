using UnityEngine;

public class LoopingGround : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float leftLimit = -30f;
    [SerializeField] private float resetDistance = 60f; 

    private void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);

        if (transform.position.x <= leftLimit)
        {
            transform.position += Vector3.right * resetDistance;
        }
    }
}