using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings _settings;
    NoiseFilter[] _noiseFilters;
        
    public ShapeGenerator(ShapeSettings settings) {
        _settings = settings;
        _noiseFilters = new NoiseFilter[settings._noiseLayers.Length];

        for(int i = 0; i < _noiseFilters.Length; i++) {
            _noiseFilters[i] = new NoiseFilter(settings._noiseLayers[i]._noiseSettings);
        }
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere) {

        float elevation = 0;
        float firstLayerValue = 0;

        if (_noiseFilters.Length > 0) {
            firstLayerValue = _noiseFilters[0].Evaluate(pointOnUnitSphere);
            if(_settings._noiseLayers[0].enabled) {
                elevation = firstLayerValue;
            }
        }

        for(int i = 1; i < _noiseFilters.Length; i++) {

            if(_settings._noiseLayers[i].enabled) {
                float mask = _settings._noiseLayers[0].useFirtLayerAsMask ? firstLayerValue : 1;

                elevation += _noiseFilters[i].Evaluate(pointOnUnitSphere) * mask;
            }
        }

        return pointOnUnitSphere * _settings._planetRadius * (1f + elevation);
    }
}
