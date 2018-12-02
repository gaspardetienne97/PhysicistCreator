using UnityEngine;


//Decides what the curve we will be contructing is
public static class Bezier
{

    //Currently constructs a parabola
    //Bezier equestion: B(t) = (1 - t)2 P0 + 2 (1 - t) t P1 + t2 P2.
    public static Vector3 GetPointQuadratic(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            oneMinusT * oneMinusT * p0 +
            2f * oneMinusT * t * p1 +
            t * t * p2;
    }


    //Used to find the tangent of each piece of the curve. Will be useful for showing our trajectory at a given point along the path
    //In the context of a line integral, this vector will be useful for when our path is a vector function (ie every point on the path is a vector)
    //The sum of all vector values (along this path) dotted with the field's value at this same poin in the path is the line integral.

    //This derivative only works for the quadtratic path given above.
    //B'(t) = 2 (1 - t) (P1 - P0) + 2 t (P2 - P1).
    public static Vector3 GetFirstDerivativeQuadratic(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        return
            2f * (1f - t) * (p1 - p0) +
            2f * t * (p2 - p1);
    }


    //Cubic Bezier Curve
    //B(t) = (1 - t)2 P0 + 2 (1 - t) t P1 + t2 P2
    public static Vector3 GetPointCubic(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            oneMinusT * oneMinusT * oneMinusT * p0 +
            3f * oneMinusT * oneMinusT * t * p1 +
            3f * oneMinusT * t * t * p2 +
            t * t * t * p3;
    }

    //Cubic first derivativve
    //B'(t) = 2 (1 - t) (P1 - P0) + 2 t (P2 - P1)
    public static Vector3 GetFirstDerivativeCubic(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            3f * oneMinusT * oneMinusT * (p1 - p0) +
            6f * oneMinusT * t * (p2 - p1) +
            3f * t * t * (p3 - p2);
    }


}
