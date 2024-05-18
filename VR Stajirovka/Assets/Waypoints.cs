using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] points;

    void OnDrawGizmos()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] != null)
            {
                Gizmos.DrawSphere(points[i].position, 1.0f);
            }
            if (i > 0 && points[i-1] != null && points[i] != null)
            {
                Gizmos.DrawLine(points[i-1].position, points[i].position);
            }
        }
    }
}
