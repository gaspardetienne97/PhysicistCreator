using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorField : MonoBehaviour {


    private int density = 100;
    private int xrange = 1000;
    private int yrange = 1000;
    private int zrange = 1000;

    public Vector3 origin;
    public Vector3 xend;
    public Vector3 yend;
    public Vector3 zend;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset()
    {

        origin = new Vector3(0, 0, 0);
        xend = new Vector3(xrange, 0, 0);
        yend = new Vector3(0, yrange, 0);
        zend = new Vector3(0, 0, zrange);


    }



}
