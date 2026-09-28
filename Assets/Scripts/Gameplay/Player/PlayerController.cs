using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action<float, float> OnHealthChanged;

    [SerializeField] private PlayerConfigSO playerConfig;
    [SerializeField] private Transform groundCheck;

    private float currentHealth;
    private Rigidbody2D rb;
    private PlayerAnimationController playerVisuals;
    private bool isGrounded;
    private bool isDead;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerVisuals = GetComponentInChildren<PlayerAnimationController>();
        currentHealth = playerConfig.MaxHealth;
    }

    private void Start()
    {
        OnHealthChanged?.Invoke(currentHealth, playerConfig.MaxHealth);
    }

    private void Update()
    {
        if (isDead) return;

        CheckGrounded();
        HandleJump();
        playerVisuals.SetRunning(GameManager.Instance.BoostActive());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.TryGetComponent<ObstacleMovement>(out _))
        {
            TakeDamage(playerConfig.DamagePerHit);
        }
    }

    private void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(0, currentHealth);

        OnHealthChanged?.Invoke(currentHealth, playerConfig.MaxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            playerVisuals.TriggerHit();
        }
    }

    private void Die()
    {
        isDead = true;
        playerVisuals.TriggerHit();
        GameManager.Instance.GameOver();
    }

    private void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, playerConfig.CheckGround, playerConfig.GroundLayer);
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
}