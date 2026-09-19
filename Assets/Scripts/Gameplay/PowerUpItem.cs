using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
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
