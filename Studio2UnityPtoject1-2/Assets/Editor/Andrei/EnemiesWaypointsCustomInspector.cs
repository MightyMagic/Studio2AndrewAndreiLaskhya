using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine.Animations;

[CustomEditor(typeof(Waypoints))]
public class EnemiesWaypointsCustomInspector : Editor
{
    ReorderableList list;
    Waypoints waypoints;
    private void OnEnable()
    {
        waypoints = (Waypoints)target;
        list = new ReorderableList(serializedObject, serializedObject.FindProperty("waypoints"));
        list.onAddCallback += Add;
        list.onRemoveCallback += Remove;
        list.onSelectCallback += OnSelect;

    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        list.DoLayoutList();

        EditorGUILayout.LabelField("Configure the waypoint structure");


        if (GUILayout.Button("Create new list"))
        {
            waypoints.SpawnNewWaypoints();
            Undo.RegisterFullObjectHierarchyUndo(target,"Created the list");
        }
        if (GUILayout.Button("Reshuffle the list"))
        {
            waypoints.ReshuffleCurrentList();
            Undo.RegisterFullObjectHierarchyUndo(target, "Reshuflled the list");

            SceneView.RepaintAll();
        }
        if (GUILayout.Button("Reverse the list"))
        {
            waypoints.ReverseList();
            SceneView.RepaintAll();
        }
        serializedObject.ApplyModifiedProperties();
    }
    private void OnSceneGUI()
    {
        if (index == -1) return;
        Vector3 pos = ((Waypoints)target).waypoints[index].transform.position;
        Quaternion rot = Quaternion.identity;
        Handles.TransformHandle(ref pos, ref rot);
        ((Waypoints)target).waypoints[index].transform.position=pos;

    }
    private void Add(ReorderableList list)
    {
        
    }
    private void Remove(ReorderableList list)
    {

    }
    int index = -1;
    private void OnSelect(ReorderableList list)
    {
        index = list.index;
    }



}
