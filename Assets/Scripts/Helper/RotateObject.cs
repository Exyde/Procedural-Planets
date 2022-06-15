using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] [Range(-2, 2)] float SpeedX = 0;
    [SerializeField] [Range(-2, 2)] float SpeedY = 0;
    [SerializeField] [Range(-2, 2)] float SpeedZ = 0;

    Transform _t;

    void Awake() => _t = transform;

    void Update()
    {
        _t.Rotate(SpeedX, SpeedY, SpeedZ);
    }
}