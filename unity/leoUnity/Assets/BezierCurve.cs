using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BezierCurve : MonoBehaviour
{
    [SerializeField]
    public Vector3[] points;

    public void Reset()
    {
        points = new Vector3[] {
            new Vector3(1f, 0f, 0f),
            new Vector3(2f, 0f, 0f),
            new Vector3(3f, 0f, 0f)
        };
    }

    public Vector3 GetPointQuadratic(float t)
    {
        return transform.TransformPoint(Bezier.GetPointQuadratic(points[0], points[1], points[2], t));
    }

    public Vector3 GetVelocityQuadratic(float t)
    {
        return transform.TransformPoint(Bezier.GetFirstDerivativeQuadratic(points[0], points[1], points[2], t)) -
            transform.position;
    }

    //Returns normalized velocity curve, for visual purposes.
    public Vector3 GetDirectionQuadratic(float t)
    {
        return GetVelocityQuadratic(t).normalized;
    }
}
