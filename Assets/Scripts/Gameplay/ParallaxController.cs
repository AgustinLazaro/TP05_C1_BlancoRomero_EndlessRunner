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
                for (int i = 0; i < layers.Length; i++)
                {
                    if (layers[i].SpriteRenderer)
                    {
                        if (layers[i].RelativeSpeed > 0f)
                        {
                            Transform layerTransform = layers[i].SpriteRenderer.transform;
                            float moveDistance = currentSpeed * layers[i].RelativeSpeed * Time.deltaTime;

                            Vector3 currentPosition = layerTransform.position;
                            currentPosition.x = currentPosition.x - moveDistance;
                            layerTransform.position = currentPosition;
                        }
                    }
                }
            }
        }
    }
}