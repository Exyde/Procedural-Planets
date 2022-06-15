using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings {

    public enum FilterType
    {
        Simple, Ridged
    };

    //Hiding based on the enum index
    [ConditionalHide("filterType", 0)]
    public SimpleNoiseSettings simpleNoiseSettings;
    [ConditionalHide("filterType", 1)]
    public RidgedNoiseSettings ridgedNoiseSettings;

    public FilterType _filterType;

    [System.Serializable]
    public class SimpleNoiseSettings
    {
        [Range(0, 8)] public float _minValue;
        [Range(0, 8)] public int _numLayers = 1;
        [Range(0, 8)] public float _strenght = 1;
        [Range(0, 4)] public float _baseRoughness;
        [Range(0, 8)] public float _roughness = 2;
        [Range(0, 1)] public float _persistence = .5f;
        public Vector3 _center;
    }

    [System.Serializable]
    public class RidgedNoiseSettings : SimpleNoiseSettings   
    {
        [Range(0, 8)] public float _weightMultiplier = 1f;
    }


}
