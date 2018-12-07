using UnityEditor;
using UnityEngine;

public class EditorGUILayoutVector3Field : UnityEditor.EditorWindow
{
    float distance = 0f;
    Vector3 obj1;
    Vector3 obj2;

    [MenuItem("Examples/Measure Distance between 2 objects")]
    static void Init()
    {
        EditorGUILayoutVector3Field window = (EditorGUILayoutVector3Field)EditorWindow.GetWindow(typeof(EditorGUILayoutVector3Field), true, "My Empty Window");
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Select an object in the Hierarchy view and click 'Capture Position'");
        EditorGUILayout.BeginHorizontal();
        obj1 = EditorGUILayout.Vector3Field("GameObject 1:", obj1);
        if (GUILayout.Button("Capture Position"))
            obj1 = Selection.activeTransform.position;
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        obj2 = EditorGUILayout.Vector3Field("GameObject 2:", obj2);
        if (GUILayout.Button("Capture Position"))
            obj2 = Selection.activeTransform.position;
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.LabelField("Distance:", distance.ToString());
        if (GUILayout.Button("Close"))
            this.Close();
    }

    void OnInspectorUpdate()
    {
        distance = Vector3.Distance(obj1, obj2);
        this.Repaint();
    }
}