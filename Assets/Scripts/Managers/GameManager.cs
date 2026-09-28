using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Configuration")]
    [SerializeField] private GameConfigSO config;

    private float baseSpeed;
    private float currentSpeed;
    private float powerUpTimer = 0f;
    private bool wasBoostActive = false;
    private float currentScore = 0f;

    public float CurrentSpeed => currentSpeed;
    public float CurrentScore => currentScore;

    private void Awake()
    {
        Instance = this;

        baseSpeed = config.InitialSpeed;
        currentSpeed = baseSpeed;
    }

    private void Update()
    {
        UpdateSpeeds();
        CalculateScore();
    }

    private void UpdateSpeeds()
    {
        if (baseSpeed < config.MaxSpeed)
        {
            baseSpeed += config.SpeedIncreaseRate * Time.deltaTime;
            baseSpeed = Mathf.Min(baseSpeed, config.MaxSpeed);
        }

        if (powerUpTimer > 0f)
        {
            powerUpTimer -= Time.deltaTime;
            currentSpeed = baseSpeed * config.BoostMultiplier;
        }
        else
        {
            currentSpeed = baseSpeed;
            if (wasBoostActive)
            {
                Debug.Log("Vuelve a velocidad normal");
                wasBoostActive = false;
            }
        }
    }

    private void CalculateScore()
    {
        currentScore += currentSpeed * config.ScoreMultiplier * Time.deltaTime;
    }

    public bool BoostActive()
    {
        return powerUpTimer > 0f;
    }

    public void TriggerPowerUp()
    {
        powerUpTimer = config.BoostDuration;
        wasBoostActive = true;
        Debug.Log($"PowerUp activado: x{config.BoostMultiplier} velocidad por {config.BoostDuration}s.");
    }
}