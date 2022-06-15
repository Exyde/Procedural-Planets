using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSettings : ScriptableObject
{
    [Range (0, 8)]
    public float _planetRadius = 1.0f;
    public NoiseLayer[] _noiseLayers;


    [System.Serializable]
    public class NoiseLayer {
        public bool enabled = true;
        public bool useFirtLayerAsMask = true;
        public NoiseSettings _noiseSettings;
    }
}
