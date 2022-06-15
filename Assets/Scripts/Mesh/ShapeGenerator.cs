using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings _settings;
    INoiseFilter[] _NoiseFilters;
    public MinMax elevationMinMax;
        
    public void UpdateSettings(ShapeSettings settings) {
        _settings = settings;
        _NoiseFilters = new INoiseFilter[settings._noiseLayers.Length];

        for(int i = 0; i < _NoiseFilters.Length; i++) {
            _NoiseFilters[i] = NoiseFilterFactory.CreateNoiseFilter(settings._noiseLayers[i]._noiseSettings);
        }

        elevationMinMax = new MinMax();
    }

    public float CalculateUnscaledElevation(Vector3 pointOnUnitSphere) {

        float elevation = 0;
        float firstLayerValue = 0;

        if (_NoiseFilters.Length > 0) {
            firstLayerValue = _NoiseFilters[0].Evaluate(pointOnUnitSphere);
            if(_settings._noiseLayers[0].enabled) {
                elevation = firstLayerValue;
            }
        }

        for(int i = 1; i < _NoiseFilters.Length; i++) {

            if(_settings._noiseLayers[i].enabled) {
                float mask = _settings._noiseLayers[i].useFirtLayerAsMask ? firstLayerValue : 1;

                elevation += _NoiseFilters[i].Evaluate(pointOnUnitSphere) * mask;
            }
        }

        elevationMinMax.AddValue(elevation);
        return elevation;
    }

    public float GetScaledElevation(float unscaledElevation)
    {
        float elevation = Mathf.Max(0, unscaledElevation);
        elevation = _settings._planetRadius * (1 + elevation);
        return elevation;
    }
}
