using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSettings : ScriptableObject
{
    [Range (0, 8)]
    public float _planetRadius = 1.0f;
    public NoiseLayer[] _noiseLayers;

    // [System.Serializable]
    public class NoiseLayer {

        public NoiseLayer(){
            enabled = true;
            useFirtLayerAsMask = true;
            _noiseSettings = new NoiseSettings();
        }

        public bool enabled = true;
        public bool useFirtLayerAsMask = true;
        public NoiseSettings _noiseSettings;
    }

    public void GenerateShapeSettings(){
        _planetRadius = Random.Range(.5f, 3f);

        int noiseLayerCount = Random.Range(1, 5);

        _noiseLayers = new NoiseLayer[noiseLayerCount];

        for (int i = 0; i < noiseLayerCount; i++)
        {
            _noiseLayers[i] = new NoiseLayer();

            if (i == 0) _noiseLayers[i].useFirtLayerAsMask = false;
        }
    }
}
