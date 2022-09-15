using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    MapGenerator generator;
    SerializedProperty sizePower;

    private void OnEnable()
    {
        generator = (MapGenerator)target;
        sizePower = serializedObject.FindProperty("sizePower");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.IntSlider(sizePower, 6, 15, label: "Size: " + Mathf.Pow(2, sizePower.intValue + generator.extraWidth) + "x" + Mathf.Pow(2, sizePower.intValue));
        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Read nationmap"))
        {
            generator.ReadNationMap();
        }
        if (GUILayout.Button(new GUIContent("Apply map", "Moves map data to game manager and map renderer")))
        {
            generator.ApplyMap();
        }

    }



}
