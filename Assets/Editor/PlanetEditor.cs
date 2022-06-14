using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor (typeof(Planet))]
public class PlanetEditor : Editor
{
    Planet _planet;
    Editor _shapeEditor;
    Editor _colorEditor;

    private void OnEnable() {
        _planet = (Planet)target;
    }

    public override void OnInspectorGUI() {

        using(var check = new EditorGUI.ChangeCheckScope()) {
            base.OnInspectorGUI();
            if(check.changed) {
                _planet.GeneratePlanet();
            }
        }

        GUILayout.Space(10);

        DrawSettingsEditor(ref _shapeEditor, _planet._shapeSettings, _planet.OnShapeSettingsUpdated, ref _planet._shapeSettingFoldout);
        DrawSettingsEditor(ref _colorEditor, _planet._colorSettings, _planet.OnColorSettingsUpdated, ref _planet._colorSettingFoldout);

        if(GUILayout.Button("Generate Planet")) {
            _planet.GeneratePlanet();
        }
    }

    void DrawSettingsEditor(ref Editor editor, Object settings, System.Action onSettingsUpdated, ref bool foldout) {

        if(settings == null) return;

        foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);
        if(!foldout) return;

        using var check = new EditorGUI.ChangeCheckScope();

        CreateCachedEditor(settings, null, ref editor); 
        editor.OnInspectorGUI();

        if(check.changed) {
            if(onSettingsUpdated != null) onSettingsUpdated();
        }

        GUILayout.Space(10);
    }

}
