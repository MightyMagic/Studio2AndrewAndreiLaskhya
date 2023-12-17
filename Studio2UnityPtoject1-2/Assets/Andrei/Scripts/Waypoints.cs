using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Header("References")]
    [HideInInspector]public List<GameObject> waypoints;

    [Header("Current Configuration")]

    [Range(2, 20)]
    [SerializeField] private int numberOfWaypoints;

    public TypeOfAreaToGenerate areaType;

    [Range(5, 200)]
    [SerializeField] float borderSize;

    [Range(0.5f, 20)]
    [SerializeField] float checkNeighbours;


    public void ClearList()
    {
        for(int i = waypoints.Count - 1;i >= 0; i--)
        {
            DestroyImmediate(waypoints[i]);
            waypoints.RemoveAt(i); 
        }
    }

    private void CLearColliders()
    {
        for (int i = waypoints.Count - 1; i >= 0; i--)
        {
            if (waypoints[i].GetComponent<SphereCollider>() != null)
            {
                DestroyImmediate(waypoints[i].GetComponent<SphereCollider>());
            }
        }
    }

    public void SpawnNewWaypoints()
    {
        ClearList();
        int count = 0;

        while(count < numberOfWaypoints)
        {
            GameObject newObject = new GameObject("Waypoint" + count);

            newObject.transform.position = GenerateSpawnPoint(areaType);

            Collider[] colliders = Physics.OverlapSphere(newObject.transform.position, checkNeighbours);

            if (colliders.Length == 0)
            {
                newObject.transform.parent = this.transform;
                waypoints.Add(newObject);
                count++;

                SphereCollider collider = newObject.AddComponent<SphereCollider>();
                collider.radius = checkNeighbours;
            }
            else
            {
                DestroyImmediate(newObject);
            }
        }

        CLearColliders();
    }

    public void ReshuffleCurrentList()
    {
        for (int i = waypoints.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, waypoints.Count - 1);

            var temp = waypoints[i];
            waypoints[i] = waypoints[j];
            waypoints[j] = temp;
        }
    }

    public void ReverseList()
    {
    
        for (int i = 0; i < (waypoints.Count / 2); i++)
        {
            int j = waypoints.Count - i - 1;

            var temp = waypoints[i];
            waypoints[i] = waypoints[j];
            waypoints[j] = temp;
        }
    }

    private Vector3 GenerateSpawnPoint(TypeOfAreaToGenerate areaType)
    {
        Vector3 spawnPoint = new Vector3();
        float x, y, z;
        switch (areaType)
        {
            case TypeOfAreaToGenerate.Plane:
                x = UnityEngine.Random.Range(-borderSize, borderSize);
                y = 0f;
                z = UnityEngine.Random.Range(-borderSize, borderSize);
                
                spawnPoint= new Vector3(x, y, z);
                break;

            case TypeOfAreaToGenerate.Box:
                 x = UnityEngine.Random.Range(-borderSize, borderSize);
                 y = UnityEngine.Random.Range(-borderSize, borderSize);
                 z = UnityEngine.Random.Range(-borderSize, borderSize);

                spawnPoint = new Vector3(x, y, z);
                break;
        }
        return spawnPoint + this.transform.position;
    }

    private void OnDrawGizmos()
    {
        DrawPerimeter();
    }

    private void DrawPerimeter()
    {
        if (waypoints != null)
        {
            for (int i = 0; i < waypoints.Count; i++)
            {
                GameObject obj1 = waypoints[i];
                GameObject obj2 = waypoints[(i + 1) % waypoints.Count];

                if (obj1 != null && obj2 != null)
                {
                    Gizmos.DrawLine(obj1.transform.position, obj2.transform.position);
                    DrawArrowHead(obj1.transform, obj2.transform);
                }
                Color color = Gizmos.color;
                color.a = 0.5f;
                Gizmos.color = color;
                Gizmos.DrawSphere(waypoints[i].transform.position, checkNeighbours);

                color.a = 1f;
                Gizmos.color = color;

            }
        }
    }

    private void DrawArrowHead(Transform obj1, Transform obj2)
    {
        Vector3 leftArrow = obj2.transform.position + Quaternion.Euler(0f, 30f, 0f) * (obj1.transform.position - obj2.transform.position).normalized * (checkNeighbours + 2f);
        Vector3 rightArrow = obj2.transform.position + Quaternion.Euler(0f, -30f, 0f) * (obj1.transform.position - obj2.transform.position).normalized * (checkNeighbours + 2f);
        Gizmos.DrawLine(obj2.position, leftArrow);
        Gizmos.DrawLine(obj2.position, rightArrow);
    }
    


    public enum TypeOfAreaToGenerate
    {
        Plane,
        Box
    }
}
