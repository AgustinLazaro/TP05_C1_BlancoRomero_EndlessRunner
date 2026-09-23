using UnityEngine;

[CreateAssetMenu(fileName = "NewBiome", menuName = "Runner/Biome Data")]
public class BiomeDataSO : ScriptableObject
{
    public string biomeName;
    public Sprite[] layerSprites;
}
