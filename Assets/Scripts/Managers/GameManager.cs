using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Speed Settings")]
    [SerializeField] private float baseSpeed = 5f;
    private float currentSpeed;

    [Header("Score Settings")]
    [SerializeField] private float scoreMultiplier = 1f;
    [SerializeField] private float currentScore;

    private float powerUpTimer = 0f;
    private bool wasBoostActive = false;

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
            currentSpeed = baseSpeed * 2f;
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
        currentScore = currentScore + scoreAdd;
        Debug.Log("Puntaje: " + currentScore.ToString("F0"));
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
        powerUpTimer = 5f;
        wasBoostActive = true;
        Debug.Log("Velocidad duplicada x 5 s.");
    }
}