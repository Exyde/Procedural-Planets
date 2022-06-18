using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// #if UNITY_EDITOR
// [System.Serializable]
// #endif
public class NoiseSettings {

    public NoiseSettings(){
        _filterType = FilterType.Simple;

        simpleNoiseSettings = new SimpleNoiseSettings();
    }

    public enum FilterType
    {
        Simple, Ridged
    };

    public FilterType _filterType;

    //Hiding based on the enum index
    [ConditionalHide("_filterType", 0)]
    public SimpleNoiseSettings simpleNoiseSettings;
    [ConditionalHide("_filterType", 1)]
    public RidgedNoiseSettings ridgedNoiseSettings;

    //[System.Serializable]
    public class SimpleNoiseSettings
    {
        public SimpleNoiseSettings(){
            _minValue = Random.Range(0f, 1f);
            _numLayers = Random.Range(1, 4);
            _strenght = Random.Range(0.1f, 2f);
            _baseRoughness = Random.Range (.8f, 2f);
            _roughness = Random.Range(1.4f, 4f);
            _persistence = Random.Range(.2f, 1.3f);
            _center = new Vector3(0, 0, 0);
        }

        [Range(0, 2)] public float _minValue = .2f;
        [Range(0, 8)] public int _numLayers = 1;
        [Range(0, 8)] public float _strenght = 1;
        [Range(0, 4)] public float _baseRoughness = 1;
        [Range(0, 8)] public float _roughness = 2;
        [Range(0, 1)] public float _persistence = .5f;
        public Vector3 _center;
    }

    //[System.Serializable]
    public class RidgedNoiseSettings : SimpleNoiseSettings   
    {
        [Range(0, 1)] public float _weightMultiplier = 1f;
    }


}
