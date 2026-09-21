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
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

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
        }

        UpdateScore();
    }

    private void UpdateScore()
    {
        float scoreAdd = currentSpeed * scoreMultiplier * Time.deltaTime;
        currentScore = currentScore + scoreAdd;
        Debug.Log("Puntaje: " + currentScore.ToString("F0"));
    }

    public void TriggerPowerUp()
    {
        powerUpTimer = 5f;
    }

}