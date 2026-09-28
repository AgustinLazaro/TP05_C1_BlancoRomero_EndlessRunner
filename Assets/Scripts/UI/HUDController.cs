using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _speedText;

    private int _lastDisplayedSpeed = -1;

    private void Update()
    {
        UpdateScoreDisplay();
        UpdateSpeedDisplay();
    }

    private void UpdateScoreDisplay()
    {
        _scoreText.text = GameManager.Instance.CurrentScore.ToString("0");
    }

    private void UpdateSpeedDisplay()
    {
        int speedInt = Mathf.FloorToInt(GameManager.Instance.CurrentSpeed);

        if (speedInt != _lastDisplayedSpeed)
        {
            _lastDisplayedSpeed = speedInt;
            _speedText.text = $"speed = {speedInt}x";
        }
    }
}