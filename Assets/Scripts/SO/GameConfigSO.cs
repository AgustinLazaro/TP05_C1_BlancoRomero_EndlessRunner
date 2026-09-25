using UnityEngine;

[CreateAssetMenu(fileName = "GameConfigSO", menuName = "Scriptable Objects/GameConfigSO")]
public class GameConfigSO : ScriptableObject
{
    [Header("Speed Progression")]
    [Tooltip("Velocidad de inicio de la partida")]
    [SerializeField] private float initialSpeed = 5f;

    [Tooltip("Velocidad maxima a la que puede llegar el juego")]
    [SerializeField] private float maxSpeed = 15f;

    [Tooltip("Aumento de velocidad por segundo")]
    [SerializeField] private float speedIncreaseRate = 0.1f;

    [Header("Power Up Settings")]
    [SerializeField] private float boostMultiplier = 2f;
    [SerializeField] private float boostDuration = 5f;

    [Header("Score Settings")]
    [SerializeField] private float scoreMultiplier = 1f;

    public float InitialSpeed => initialSpeed;
    public float MaxSpeed => maxSpeed;
    public float SpeedIncreaseRate => speedIncreaseRate;
    public float BoostMultiplier => boostMultiplier;
    public float BoostDuration => boostDuration;
    public float ScoreMultiplier => scoreMultiplier;
}