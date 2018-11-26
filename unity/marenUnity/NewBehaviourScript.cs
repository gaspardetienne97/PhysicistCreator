using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public Color startColor;
    public Color endColor;
    public float StartWidth;
    public float EndWidth;

    // Use this for initialization
    void Start () 
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update () 
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        //lineRenderer.startWidth = StartWidth;
        //lineRenderer.endWidth = EndWidth;
        gameObject.GetComponent<LineRenderer>().SetWidth(StartWidth , EndWidth);
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
    }
}
