using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public List<GameObject> waypoints;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            GameObject obj1 = waypoints[i];
            GameObject obj2 = waypoints[(i + 1) % waypoints.Count];

            if (obj1 != null && obj2 != null)
            {
                Gizmos.DrawLine(obj1.transform.position, obj2.transform.position);
            }
        }
    }
}
