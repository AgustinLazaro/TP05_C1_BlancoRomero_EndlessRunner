using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerConfigSO playerConfig;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float rayDistance = 0.2f;

    private Rigidbody2D rb;
    private PlayerAnimationController playerVisuals;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerVisuals = GetComponentInChildren<PlayerAnimationController>();
    }

    private void Update()
    {
        CheckGrounded();
        HandleJump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ObstacleMovement>(out _))
        {
            playerVisuals.TriggerHit();
        }
    }

    private void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, rayDistance, playerConfig.GroundLayer);
        isGrounded = hit.collider;

        playerVisuals.SetGrounded(isGrounded);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * playerConfig.JumpForce, ForceMode2D.Impulse);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * rayDistance);
    }
}