using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Speed Settings")]
    [SerializeField] private float baseSpeed = 5f;
    private float currentSpeed;

    [Header("Score Settings")]
    [SerializeField] private float scoreMultiplier = 1f;
    private float currentScore;

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public float GetCurrentScore()
    {
        return currentScore;
    }

    private void Awake()
    {
        Instance = this;
        currentSpeed = baseSpeed;
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        float scoreToAdd = currentSpeed * scoreMultiplier * Time.deltaTime;
        currentScore = currentScore + scoreToAdd;
    }

    public void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        currentSpeed = baseSpeed;
    }
}