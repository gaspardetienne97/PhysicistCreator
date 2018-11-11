using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour {

    public LineRenderer lineRenderer;
    public Transform Point0, Point1;

    private int numPoints = 50;
    private Vector3[] positions = new Vector3[50];

	// Use this for initialization
	void Start () {
        lineRenderer.positionCount = numPoints;
        DrawLinearCurve();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void DrawLinearCurve() {
        for (int i = 1; i < numPoints + 1; i++) {
            float t = i / (float)numPoints;
            positions[i - 1] = CalculateLinearBezierPoint(t, Point0.position, Point1.position);
        }
        lineRenderer.SetPositions(positions);
    }

    private Vector3 CalculateLinearBezierPoint(float t, Vector3 p0, Vector3 p1){
        return p0 + t * (p1 - p0);
    } 
}
