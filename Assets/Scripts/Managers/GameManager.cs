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
        float scoreAdd = currentSpeed * scoreMultiplier * Time.deltaTime;
        currentScore = currentScore + scoreAdd;
        Debug.Log("Puntaje: " + currentScore.ToString("F0"));
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