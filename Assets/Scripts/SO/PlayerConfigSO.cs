using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfigSO", menuName = "Scriptable Objects/PlayerConfigSO")]
public class PlayerConfigSO : ScriptableObject
{
    [Header("Jump Config")]
    [Tooltip("aplicar fuerza en el Eje Y al apretar space")]
    [SerializeField] private float jumpForce = 10f;

    [Header("Check Ground")]
    [Tooltip("Radio del overlapeo para ver si toca el ground")]
    [SerializeField] private float checkGround = 0.2f;

    [Tooltip("Capa que define el ground")]
    [SerializeField] private LayerMask groundLayer;

    public float JumpForce => jumpForce;
    public float CheckGround => checkGround;
    public LayerMask GroundLayer => groundLayer;
}
