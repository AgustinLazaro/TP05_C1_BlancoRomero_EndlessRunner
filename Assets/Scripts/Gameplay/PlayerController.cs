using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerConfigSO playerConfig;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float rayDistance = 0.2f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, rayDistance, playerConfig.GroundLayer);

            if (hit.collider)
            {
                rb.AddForce(Vector2.up * playerConfig.JumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * rayDistance);
    }
}