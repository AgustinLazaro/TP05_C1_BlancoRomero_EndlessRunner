using System;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameManager gameManager;

    [Header("Parallax Layers")]
    [SerializeField] private ParallaxLayerData[] layers;

    [Serializable] public struct ParallaxLayerData
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [Range(0f, 1f)]
        [SerializeField] private float relativeSpeed;

        public SpriteRenderer SpriteRenderer => spriteRenderer;
        public float RelativeSpeed => relativeSpeed;
    }

    private void Update()
    {
        if (gameManager)
        {
            float currentSpeed = gameManager.CurrentSpeed;

            if (currentSpeed > 0f)
            {
                // Solo para verificar en consola que lee la velocidad
                // Debug.Log($"Game speed: {currentSpeed}");
            }
        }
    }
}