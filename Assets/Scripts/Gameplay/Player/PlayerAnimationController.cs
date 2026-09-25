using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetGrounded(bool isGrounded)
    {
        animator.SetBool("IsGrounded", isGrounded);
    }

    public void SetRunning(bool isRunning)
    {
        animator.SetBool("IsRunning", isRunning);
    }
}