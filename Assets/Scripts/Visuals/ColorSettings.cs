using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ColorSettings : ScriptableObject
{
    public Material planetMaterial;
    public BiomeColorSettings biomeColorSettings;

    [System.Serializable]
    public class BiomeColorSettings
    {
        public Biome[] biomes;
        public NoiseSettings noise;
        [Range(0, 1)] public float noiseOffset;
        [Range (0, 8)] public float noiseStrenght;
        [Range(0, 1)] public float blendAmount;


        [System.Serializable]
        public class Biome
        {
            public Gradient gradient;
            public Color tint;
            [Range(0, 1)] public float tintPercent;
            [Range(0, 1)] public float startHeight;

        }
    }
}
