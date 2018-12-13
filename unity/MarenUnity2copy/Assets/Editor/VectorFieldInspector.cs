using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(VectorField))]
public class VectorFieldInspector : Editor
{

    // Use this for initialization
    private VectorField vfield;
    private Transform handleTransform;
    private Quaternion handleRotation;


    

    private void OnSceneGUI()
    {

        vfield = target as VectorField;
        handleTransform = vfield.transform;
        handleRotation = Tools.pivotRotation == PivotRotation.Local ?
            handleTransform.rotation : Quaternion.identity;

        
        Vector3 p0 = ShowPoint(0);
        Vector3 px = ShowPoint(1);
        Vector3 py = ShowPoint(2);
        Vector3 pz = ShowPoint(3);

        Handles.color = Color.white;


        Handles.DrawLine(p0, px);
        Handles.DrawLine(p0, py);
        Handles.DrawLine(p0, pz);
        



    }


    //Modified to provide a nicer UI
    private const float handleSize = 0.04f;
    private const float pickSize = 0.06f;
    private int selectedIndex = -1;

    private Vector3 ShowPoint(int index)
    {

        Vector3 point;
        if (index == 0) {
            point = handleTransform.TransformPoint(vfield.origin);
        }
        else if (index == 1) {
            point = handleTransform.TransformPoint(vfield.xend);
        }
        else if (index == 2) {
            point = handleTransform.TransformPoint(vfield.yend);
        }
        else {
            point = handleTransform.TransformPoint(vfield.zend);
        } 



        float size = HandleUtility.GetHandleSize(point);

        if (index >-1 && index != 0)
        {
            Handles.color = Color.gray;
        } else
        {
        Handles.color = Color.white;

        }

        if (Handles.Button(point, handleRotation, size * handleSize, size * pickSize, Handles.DotCap))
        {
            selectedIndex = index;
            Repaint();
        }

        if (selectedIndex == index && selectedIndex != 0)
        {
            EditorGUI.BeginChangeCheck();
            point = Handles.DoPositionHandle(point, handleRotation);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(vfield, "Move Point");
                EditorUtility.SetDirty(vfield);
            }
        }
        return point;
    }


}
