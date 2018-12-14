using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(LineRenderer))]



public class BezierSpline : MonoBehaviour
{
    [SerializeField]
    private Vector3[] points;

    [SerializeField]
    private BezierControlPointMode[] modes;

    //Allows us to add loops to our path
    [SerializeField]
    private bool loop;

    public string Types = "Path Types";

    [SerializeField]
    private bool Scalar;

    [SerializeField]
    private bool Vector;

    public bool CameraSpline;



    private int curveCount;
    private int layerOrder = 0;

    private int SEGMENT_COUNT = 50;

    private int DERIVATIVE_SEGMENT_COUNT = 20;
    private int DerivativeLength = 20;

    private int CURTAIN_SEGMENT_COUNT = 50;
    private int CurtainLength = 20;


    public LineRenderer curveRenderer;
    public List<LineRenderer> derivativeLines;
    public List<LineRenderer> curtainLines;


    //All of this code handles rendering the curve in game, as opposed to just in scene
    void Start()
    {
        if (!curveRenderer)
        {
            curveRenderer = GetComponent<LineRenderer>();
            derivativeLines = new List<LineRenderer>();
            curtainLines = new List<LineRenderer>();

        }
        curveRenderer.sortingLayerID = layerOrder;
        curveCount = (int)points.Length / 3;

        if (!CameraSpline)
        {
            DrawCurve2();
        }

        if (Scalar) {DrawCurtain();}
        if (Vector) { DrawDerivative(); }

    }
    void Update()
    {


    }
    void DrawCurve()
    {

        for (int j = 0; j < curveCount; j++)
        {
            for (int i = 1; i <= SEGMENT_COUNT; i++)
            {
                float t = i / (float)SEGMENT_COUNT;
                int nodeIndex = j * 3;
                Vector3 pixel = Bezier.GetPointCubic(points[nodeIndex], points[nodeIndex + 1], points[nodeIndex + 2], points[nodeIndex + 3], t);
                curveRenderer.SetVertexCount(((j * SEGMENT_COUNT) + i));
                curveRenderer.SetPosition((j * SEGMENT_COUNT) + (i - 1), pixel);
            }

        }
        
        if (loop) {
            curveRenderer.loop = true;
        }
        
    }
    
    //Modified Version which should allow for ingame handling
    void DrawCurve2()
    {
        curveRenderer.SetVertexCount(SEGMENT_COUNT);
        for (int i = 0;  i < SEGMENT_COUNT; i++) {
            Vector3 point = GetPoint(i / (float)SEGMENT_COUNT);
            curveRenderer.SetPosition(i, point);
        }
        if (loop)
        {
            curveRenderer.loop = true;
        }
        Material myMaterial = (Material)Resources.Load("ArrowAsset/MyBlue", typeof(Material));
        curveRenderer.material= myMaterial;
        //curveRenderer.material.color = Color.blue;

    }


    void DrawDerivative()
    {

        for (int i = 0; i < DERIVATIVE_SEGMENT_COUNT; i++)
        {
            LineRenderer lRend = new GameObject().AddComponent<LineRenderer>() as LineRenderer;

            Vector3 vertex = GetPoint(i / (float)DERIVATIVE_SEGMENT_COUNT);

            lRend.SetVertexCount(2);
            lRend.SetPosition(0, vertex);
            lRend.SetPosition(1, vertex + GetDirection(i / (float)DERIVATIVE_SEGMENT_COUNT)*DerivativeLength);

            //lRend.material.color = Color.green;
            Material myMaterial3 = (Material)Resources.Load("ArrowAsset/MyRed", typeof(Material));
            lRend.material = myMaterial3;



            derivativeLines.Add(lRend);
            derivativeLines[i].enabled = true;

        }

    }

    void DrawCurtain()
    {
        for (int i = 0; i < CURTAIN_SEGMENT_COUNT; i++)
        {
            LineRenderer lRend = new GameObject().AddComponent<LineRenderer>() as LineRenderer;

            Vector3 vertex = GetPoint(i / (float)CURTAIN_SEGMENT_COUNT);

            lRend.SetVertexCount(2);
            lRend.SetPosition(0, vertex);

            Vector3 vertex2 = new Vector3(vertex.x, 0, vertex.z);
            lRend.SetPosition(1, vertex2);

            //lRend.material.Color = Color.red;
            Material myMaterial2 = (Material)Resources.Load("ArrowAsset/MyRed", typeof(Material));
            lRend.material = myMaterial2;



            curtainLines.Add(lRend);
            curtainLines[i].enabled = true;

        }
    }




    //End of the rendering code


    public bool Loop
    {
        get
        {
            return loop;
        }
        set
        {
            loop = value;
            if (value == true)
            {
                modes[modes.Length - 1] = modes[0];
                SetControlPoint(0, points[0]);
            }
        }
    }

    public BezierControlPointMode GetControlPointMode(int index)
    {
        return modes[(index + 1) / 3];
    }

    public void SetControlPointMode(int index, BezierControlPointMode mode)
    {
        int modeIndex = (index + 1) / 3;
        modes[modeIndex] = mode;
        if (loop)
        {
            if (modeIndex == 0)
            {
                modes[modes.Length - 1] = mode;
            }
            else if (modeIndex == modes.Length - 1)
            {
                modes[0] = mode;
            }
        }
        EnforceMode(index);
    }

    //Everything up to the next comment concerns itself with fixing the lack of derivative at the connecting points.
    //Implementing this will be important for the closed loop path
    public int ControlPointCount
    {
        get
        {
            return points.Length;
        }
    }

    public Vector3 GetControlPoint(int index)
    {
        return points[index];
        EnforceMode(index);
    }

    public void SetControlPoint(int index, Vector3 point)
    {
        if (index % 3 == 0)
        {
            Vector3 delta = point - points[index];
            if (loop)
            {
                if (index == 0)
                {
                    points[1] += delta;
                    points[points.Length - 2] += delta;
                    points[points.Length - 1] = point;
                }
                else if (index == points.Length - 1)
                {
                    points[0] = point;
                    points[1] += delta;
                    points[index - 1] += delta;
                }
                else
                {
                    points[index - 1] += delta;
                    points[index + 1] += delta;
                }
            }
            else
            {
                if (index > 0)
                {
                    points[index - 1] += delta;
                }
                if (index + 1 < points.Length)
                {
                    points[index + 1] += delta;
                }
            }
        }
        points[index] = point;
        EnforceMode(index);
    }

    private void EnforceMode(int index)
    {

        int modeIndex = (index + 1) / 3;
        BezierControlPointMode mode = modes[modeIndex];
        if (mode == BezierControlPointMode.Free || !loop && (modeIndex == 0 || modeIndex == modes.Length - 1))
        {
            return;
        }

        int middleIndex = modeIndex * 3;
        int fixedIndex, enforcedIndex;

        if (index <= middleIndex)
        {
            fixedIndex = middleIndex - 1;
            if (fixedIndex < 0)
            {
                fixedIndex = points.Length - 2;
            }
            enforcedIndex = middleIndex + 1;
            if (enforcedIndex >= points.Length)
            {
                enforcedIndex = 1;
            }
        }
        else
        {
            fixedIndex = middleIndex + 1;
            if (fixedIndex >= points.Length)
            {
                fixedIndex = 1;
            }
            enforcedIndex = middleIndex - 1;
            if (enforcedIndex < 0)
            {
                enforcedIndex = points.Length - 2;
            }
        }
        Vector3 middle = points[middleIndex];
        Vector3 enforcedTangent = middle - points[fixedIndex];
        if (mode == BezierControlPointMode.Aligned)
        {
            enforcedTangent = enforcedTangent.normalized * Vector3.Distance(middle, points[enforcedIndex]);
        }
        points[enforcedIndex] = middle + enforcedTangent;
    }


    //Action taken when resetting in Inspector
    public void Reset()
    {
        points = new Vector3[] {
            new Vector3(100f, 0f, 0f),
            new Vector3(2f, 100f, 0f),
            new Vector3(3f, 0f, 100f),
            new Vector3(400f, 0f, 0f)
        };

        modes = new BezierControlPointMode[] {
            BezierControlPointMode.Free,
            BezierControlPointMode.Free
        };
    }


    //Everything below concerns itself with drawing the curve as a cubic function
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

        //Put a coefficient in front to scale as desired
        return GetVelocity(t).normalized;

        //return GetVelocity(t);

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

        Array.Resize(ref modes, modes.Length + 1);
        modes[modes.Length - 1] = modes[modes.Length - 2];

        EnforceMode(points.Length - 4);

        if (loop)
        {
            points[points.Length - 1] = points[0];
            modes[modes.Length - 1] = modes[0];
            EnforceMode(0);
        }

    }




}