using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BezierCubic))]
public class BezierCubicInspector : Editor
{

    private BezierCubic curve;
    private Transform handleTransform;
    private Quaternion handleRotation;


    private const int lineSteps = 10;

    private void OnSceneGUI()
    {

        curve = target as BezierCubic;
        handleTransform = curve.transform;
        handleRotation = Tools.pivotRotation == PivotRotation.Local ?
            handleTransform.rotation : Quaternion.identity;

        Vector3 p0 = ShowPoint(0);
        Vector3 p1 = ShowPoint(1);
        Vector3 p2 = ShowPoint(2);

        //Added for cubic
        Vector4 p3 = ShowPoint(3);

        //Draws the lines between all of our points.
        Handles.color = Color.gray;
        Handles.DrawLine(p0, p1);
        Handles.DrawLine(p1, p2);

        //Added for cubic
        Handles.DrawLine(p2, p3);


        Handles.color = Color.white;
        Vector3 lineStart = curve.GetPointCubic(0f);


        Handles.color = Color.green;
        Handles.DrawLine(lineStart, lineStart + curve.GetVelocityCubic(0f));
        for (int i = 1; i <= lineSteps; i++)
        {

            Vector3 lineEnd = curve.GetPointCubic(i / (float)lineSteps);
            Handles.color = Color.white;
            Handles.DrawLine(lineStart, lineEnd);
            Handles.color = Color.green;
            Handles.DrawLine(lineEnd, lineEnd + curve.GetVelocityCubic(i / (float)lineSteps));
            lineStart = lineEnd;
        }
    }



    private Vector3 ShowPoint(int index)
    {
        Vector3 point = handleTransform.TransformPoint(curve.points[index]);
        EditorGUI.BeginChangeCheck();
        point = Handles.DoPositionHandle(point, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(curve, "Move Point");
            EditorUtility.SetDirty(curve);
            curve.points[index] = handleTransform.InverseTransformPoint(point);
        }
        return point;
    }
}