using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFactory : MonoBehaviour
{

    public int _planetCount = 10;
    public float _timeBtwPlanet = .5f;
    public float _offset = 5f;

    public bool _randomizePosition;
    public float _worldRange = 100f;


    void Start()
    {
        StartCoroutine(CreateAllPlanets());
    }

    IEnumerator CreateAllPlanets(){
        for (int i = 0; i < _planetCount; i++)
        {
            CreatePlanet(i);
            yield return new WaitForSeconds(_timeBtwPlanet);

        }
    }

    void CreatePlanet(int index){
        GameObject planet = new GameObject("Planet " + index);
        planet.AddComponent<Planet>();

        if (_randomizePosition){
            planet.transform.position = new Vector3(
                Random.Range(-_worldRange, _worldRange),
                Random.Range(-_worldRange, _worldRange),
                Random.Range(-_worldRange, _worldRange)
            );
        } else {
            planet.transform.position = new Vector3(index * _offset, 0, 0);
        }

        planet.transform.parent = this.transform;
    }
}
