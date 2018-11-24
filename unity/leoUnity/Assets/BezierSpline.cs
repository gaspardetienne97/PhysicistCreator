using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class BezierSpline : MonoBehaviour
{
    [SerializeField]
    public Vector3[] points;

    public void Reset()
    {
        points = new Vector3[] {
            new Vector3(1f, 0f, 0f),
            new Vector3(2f, 0f, 0f),
            new Vector3(3f, 0f, 0f),
            new Vector3(4f, 0f, 0f)
        };
    }

    public Vector3 GetPoint(float t)
    {

        int i;
        if (t >= 1f)
        {
            t = 1f;
            i = points.Length - 4;
        }
        else
        {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }

        return transform.TransformPoint(Bezier.GetPointCubic(points[i], points[i+1], points[i+2], points[i+3], t));
    }

    public Vector3 GetVelocity(float t)
    {

        int i;
        if (t >= 1f)
        {
            t = 1f;
            i = points.Length - 4;
        }
        else
        {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }
        return transform.TransformPoint(
            Bezier.GetFirstDerivativeCubic(points[i], points[i+1], points[i+2], points[i+3], t)) - transform.position;
    }

    //Returns normalized velocity curve, for visual purposes.
    public Vector3 GetDirection(float t)
    {
        return GetVelocity(t);

        //Uncomment to normalize
        //return GetVelocity(t).normalized;

    }


    public int CurveCount
    {
        get
        {
            return (points.Length - 1) / 3;
        }
    }

    public void AddCurve()
    {
        Vector3 point = points[points.Length - 1];
        Array.Resize(ref points, points.Length + 3);
        point.x += 1f;
        points[points.Length - 3] = point;
        point.x += 1f;
        points[points.Length - 2] = point;
        point.x += 1f;
        points[points.Length - 1] = point;
    }
}