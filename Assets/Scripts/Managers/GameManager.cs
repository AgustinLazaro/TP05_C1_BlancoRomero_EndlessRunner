using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Configuration")]
    [SerializeField] private GameConfigSO config;

    private float baseSpeed;
    private float currentSpeed;
    private float powerUpTimer = 0f;
    private bool wasBoostActive = false;

    [Header("Score Settings")]
    [SerializeField] private float currentScore;
    [SerializeField] private TextMeshProUGUI scoreText;

    public float CurrentSpeed => currentSpeed;

    private void Awake()
    {
        Instance = this;

        baseSpeed = config.InitialSpeed;
        currentSpeed = baseSpeed;
    }

    private void Update()
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

        UpdateScore();
    }

    private void UpdateScore()
    {
        float scoreAdd = currentSpeed * config.ScoreMultiplier * Time.deltaTime;
        currentScore += scoreAdd;
        scoreText.text = currentScore.ToString("0");
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
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