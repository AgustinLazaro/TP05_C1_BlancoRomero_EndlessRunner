using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Speed Settings")]
    [SerializeField] private float baseSpeed = 5f;
    private float currentSpeed;

    [Header("Power Up Settings")]
    [SerializeField] private float boostMultiplier = 2f;
    [SerializeField] private float boostDuration = 5f;
    private float powerUpTimer = 0f;
    private bool wasBoostActive = false;

    [Header("Score Settings")]
    [SerializeField] private float scoreMultiplier = 1f;
    [SerializeField] private float currentScore;
    [SerializeField] private TextMeshProUGUI scoreText;

    public float CurrentSpeed => currentSpeed;
    private void Awake()
    {
        Instance = this;
        currentSpeed = baseSpeed;
    }

    private void Update()
    {
        if (powerUpTimer > 0f)
        {
            powerUpTimer -= Time.deltaTime;
            currentSpeed = baseSpeed * boostMultiplier;
        }
        else
        {
            currentSpeed = baseSpeed;
            if (wasBoostActive)
            {
                Debug.Log("vuelve a velocidad normal");
                wasBoostActive = false;
            }
        }

        UpdateScore();
    }

    private void UpdateScore()
    {
        float scoreAdd = currentSpeed * scoreMultiplier * Time.deltaTime;
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
        powerUpTimer = boostDuration;
        wasBoostActive = true;
        Debug.Log($"PowerUp activado: x{boostMultiplier} velocidad por {boostDuration}s.");
    }
}