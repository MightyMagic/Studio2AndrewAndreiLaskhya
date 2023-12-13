using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(Waypoints))]
public class EnemiesWaypointsCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();

        EditorGUILayout.LabelField("Configure the waypoint structure");

        Waypoints waypoints = (Waypoints)target;

        if (GUILayout.Button("Create new list"))
        {
            waypoints.SpawnNewWaypoints();
        }
        if (GUILayout.Button("Reshuffle the list"))
        {
            waypoints.ReshuffleCurrentList();
            SceneView.RepaintAll();
        }

        serializedObject.ApplyModifiedProperties();
    }



   
}
