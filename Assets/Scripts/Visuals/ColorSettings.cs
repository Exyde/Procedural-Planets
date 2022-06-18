using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu()]
public class ColorSettings : ScriptableObject
{
    public Material planetMaterial;
    public BiomeColorSettings biomeColorSettings;
    public Gradient oceanColor;

    public void GenerateColorSettings(){
        // planetMaterial = (Material)AssetDatabase.LoadAssetAtPath("Assets/Graphics/M_Planet.mat", typeof(Material));
        
        planetMaterial = new Material(Shader.Find("Shader Graphs/Planet"));
        oceanColor = GetRandomGradient();
        biomeColorSettings = new BiomeColorSettings();
    }

 //   [System.Serializable]
    public class BiomeColorSettings
    {
        public BiomeColorSettings(){

            noiseOffset = Random.Range(0.0f, 1.0f);
            noiseStrenght = Random.Range(0.0f, 8.0f);
            blendAmount = Random.Range(0.0f, 1.0f);

            int biomeCount = Random.Range(1, 4);
            biomes = new Biome[biomeCount];

            for (int i = 0; i < biomeCount; i++)
            {
                biomes[i] = new Biome();
            }

            noise = new NoiseSettings();

        }

        public Biome[] biomes;
        public NoiseSettings noise;
        [Range(0, 1)] public float noiseOffset;
        [Range (0, 8)] public float noiseStrenght;
        [Range(0, 1)] public float blendAmount;


        [System.Serializable]
        public class Biome
        {
            public Biome(){
                gradient = ColorSettings.GetRandomGradient();
                tint = GetRandomColor();
                tintPercent = Random.Range(0.0f, 1.0f);
                startHeight = Random.Range(0.0f, 1.0f);
            }

            public Gradient gradient;
            public Color tint;
            [Range(0, 1)] public float tintPercent;
            [Range(0, 1)] public float startHeight;

        }
    }

    public static Gradient GetRandomGradient(){
        Gradient g = new Gradient();
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;

        int KeyCount = Random.Range(1, 6);

        colorKey = new GradientColorKey[KeyCount];
        alphaKey = new GradientAlphaKey[KeyCount];

        for (int i = 0; i < KeyCount; i++)
        {
            colorKey[i].color = GetRandomColor();
            colorKey[i].time = Random.Range(0.0f, 1.0f);
            alphaKey[i].alpha = Random.Range(0.0f, 1.0f);
            alphaKey[i].time = Random.Range(0.0f, 1.0f);
        }
        
        g.SetKeys(colorKey, alphaKey);

        return g;
    }
    
    public static Color GetRandomColor(){
        Color c = new Color(
            Random.Range (0f, 1f),
            Random.Range (0f, 1f),
            Random.Range (0f, 1f),
            1.0f
        );

        return c;
    }
}
