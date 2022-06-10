using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    [Range(2, 256)]
    [SerializeField] int _resolution = 10;


    [Header("Settings")]
    [SerializeField] ShapeSettings _shapeSettings;
    [SerializeField] ColorSettings _colorSettings;

    ShapeGenerator _shapeGenerator;

    [SerializeField, HideInInspector]
    MeshFilter[] _meshFilters;
    TerrainFace[] _terrainFaces;


    private void OnValidate() {
        GeneratePlanet();
    }

    void Initalize() {


        _shapeGenerator = new ShapeGenerator(_shapeSettings);

        if (_meshFilters == null || _meshFilters.Length == 0)
            _meshFilters = new MeshFilter[6];

        _terrainFaces = new TerrainFace[6];

        Vector3[] directions = {
            Vector3.up, Vector3.down,
            Vector3.left, Vector3.right,
            Vector3.forward, Vector3.back
        };


        for(int i = 0; i < 6; i++) {

            if (_meshFilters[i] == null) {
                GameObject meshObj = new GameObject("Mesh");
                meshObj.transform.parent = this.transform;

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                _meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                _meshFilters[i].sharedMesh = new Mesh();
            }

            _terrainFaces[i] = new TerrainFace(_shapeGenerator, _meshFilters[i].sharedMesh, _resolution, directions[i]);
        }
    }

    #region Generation Methods
    public void GeneratePlanet() {
        Initalize();
        GenerateMesh();
        GenerateColours();
    }

    public void OnShapeSettingsUpdated() {
        Initalize();
        GenerateMesh();
    }

    public void OnColorSettingsUpdated() {
        Initalize();
        GenerateColours();
    }


    void GenerateMesh() {
        foreach (TerrainFace face in _terrainFaces) {
            face.ConstructMesh();
        }
    }

    void GenerateColours() {
        foreach (MeshFilter filter in _meshFilters) {
            filter.GetComponent<MeshRenderer>().sharedMaterial.color = _colorSettings.planetColor;
        }
    }
    #endregion
}