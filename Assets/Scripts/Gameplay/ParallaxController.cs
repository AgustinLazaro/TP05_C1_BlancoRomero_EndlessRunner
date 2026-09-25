using System;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [Serializable]
    public struct ParallaxLayerData
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [Range(0f, 1f)]
        [SerializeField] private float relativeSpeed;
        [SerializeField] private float leftLimit;
        [SerializeField] private float resetDistance;

        public SpriteRenderer SpriteRenderer => spriteRenderer;
        public float RelativeSpeed => relativeSpeed;
        public float LeftLimit => leftLimit;
        public float ResetDistance => resetDistance;
    }

    [Header("Dependencies")]
    [SerializeField] private GameManager gameManager;

    [Header("Parallax Layers")]
    [SerializeField] private ParallaxLayerData[] layers;

    private void Update()
    {
        if (!gameManager) return;

        float currentSpeed = gameManager.CurrentSpeed;
        if (currentSpeed <= 0f) return;

        for (int i = 0; i < layers.Length; i++)
        {
            ParallaxLayerData layer = layers[i];
            if (layer.RelativeSpeed <= 0f) continue;

            Transform layerTransform = layer.SpriteRenderer.transform;
            float moveDistance = currentSpeed * layer.RelativeSpeed * Time.deltaTime;

            layerTransform.position += Vector3.left * moveDistance;

            if (layer.ResetDistance > 0f)
            {
                if (layerTransform.position.x <= layer.LeftLimit)
                {
                    layerTransform.position += Vector3.right * layer.ResetDistance;
                }
            }
           
        }
    }
}