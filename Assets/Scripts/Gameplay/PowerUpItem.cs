using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    private void Update()
    {
        float currentSpeed = GameManager.Instance.GetCurrentSpeed();
        transform.position += Vector3.left * (currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            Debug.Log(" power up agarrado");
            gameObject.SetActive(false);
        }
    }
}