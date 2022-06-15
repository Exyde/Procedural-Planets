using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNoiseFilter : INoiseFilter
{

    NoiseSettings.SimpleNoiseSettings _settings;
    Noise _noise = new Noise();

    public SimpleNoiseFilter(NoiseSettings.SimpleNoiseSettings settings) {
        _settings = settings;
    }

    public float Evaluate(Vector3 point) {
        float noiseValue = 0;
        Vector3 center = _settings._center;
        float frequency = _settings._baseRoughness;
        float amplitude = 1;

        for(int i = 0; i < _settings._numLayers; i++) {
            float value = _noise.Evaluate(point * frequency + center);
            noiseValue += (value + 1) * .5f * amplitude;
            frequency *= _settings._roughness;
            amplitude *= _settings._persistence;
        }

        noiseValue = Mathf.Max(0, noiseValue - _settings._minValue);

        return noiseValue * _settings._strenght;
    }
}
