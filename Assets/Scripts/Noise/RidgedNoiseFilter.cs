using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidgedNoiseFilter : INoiseFilter
{

    NoiseSettings.RidgedNoiseSettings _settings;
    Noise _noise = new Noise();

    public RidgedNoiseFilter(NoiseSettings.RidgedNoiseSettings settings)
    {
        _settings = settings;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        Vector3 center = _settings._center;
        float frequency = _settings._baseRoughness;
        float amplitude = 1;

        float weight = 1;

        for (int i = 0; i < _settings._numLayers; i++)
        {
            float value = 1 - Mathf.Abs(_noise.Evaluate(point * frequency + center));
            value *= value;
            value *= _settings._weightMultiplier;
            weight = Mathf.Clamp01(value * _settings._weightMultiplier);

            noiseValue += value * amplitude;
            frequency *= _settings._roughness;
            amplitude *= _settings._persistence;
        }

        noiseValue = noiseValue - _settings._minValue;

        return noiseValue * _settings._strenght;
    }
}
