using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings {

    [Range(0, 8)] public float _minValue;

    [Range(0, 8)] public int _numLayers = 1;

    [Range (0, 8)] public float _strenght = 1;

    [Range(0, 4)] public float _baseRoughness;
    [Range(0, 8)] public float _roughness = 2;

    [Range(0, 1)] public float _persistence = .5f;


    public Vector3 _center;
}
