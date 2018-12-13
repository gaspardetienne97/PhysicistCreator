using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]

public class VectorField : MonoBehaviour {


    public static int density = 100;
    public static int xrange = 1000;
    public static int yrange = 1000;
    public static int zrange = 1000;

    public Vector3 origin;
    public Vector3 xend;
    public Vector3 yend;
    public Vector3 zend;

    //private GameObject[,,] cartesian = new GameObject[(int)xrange / density, (int)yrange / density, (int)zrange / density];


    public LineRenderer curveRenderer;
    public List<LineRenderer> cartesianLines;

    // Use this for initialization
    void Start () {

        if (!curveRenderer)
        {
            curveRenderer = GetComponent<LineRenderer>();
            cartesianLines = new List<LineRenderer>();



        }

        LineRenderer lRend1 = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
        lRend1.SetVertexCount(2);
        lRend1.SetPosition(0, origin);
        lRend1.SetPosition(1, xend);
        lRend1.material.color = Color.white;
        lRend1.enabled = true;
        cartesianLines.Add(lRend1);


        LineRenderer lRend2 = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
        lRend2.SetVertexCount(2);
        lRend2.SetPosition(0, origin);
        lRend2.SetPosition(1, yend);
        lRend2.material.color = Color.white;
        lRend2.enabled = true;
        cartesianLines.Add(lRend2);


        LineRenderer lRend3 = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
        lRend3.SetVertexCount(2);
        lRend3.SetPosition(0, origin);
        lRend3.SetPosition(1, zend);
        lRend3.material.color = Color.white;
        lRend3.enabled = true;
        cartesianLines.Add(lRend3);

        //cartesian = new GameObject[(int)xrange / density, (int)yrange / density, (int)zrange / density];
        //Material material = Resources.Load("ArrowAsset/materials", typeof(Material)) as Material;
        Mesh myMesh = (Mesh)Resources.Load("ArrowAsset/model", typeof(Mesh));

        //Material mat = Resources.Load("ArrowAsset/materials") as Material;

        GameObject prefab = new GameObject("Arrows");
        prefab.transform.localScale += new Vector3(50, 50, 50);
        prefab.transform.LookAt(Vector3.zero);
        prefab.AddComponent<MeshFilter>();
        prefab.AddComponent<MeshRenderer>();
        prefab.GetComponent<MeshFilter>().sharedMesh = myMesh;
        prefab.GetComponent<MeshRenderer>().material.color = Color.white;




        for (int i = 0; i < (int)xrange / density; i = i + 1)
        {
            for (int j = 0; j < (int)yrange / density; j = j + 1)
            {
                for (int k = 0; k < (int)zrange / density; k = k + 1)
                {
                    /*
                    cartesian[i, j, k] = new GameObject();
                    cartesian[i, j, k].transform.position = new Vector3(i * density, j * density, k * density);
                    cartesian[i, j, k].AddComponent<MeshFilter>();
                    cartesian[i, j, k].AddComponent<MeshRenderer>();
                    cartesian[i, j, k].GetComponent<MeshFilter>().sharedMesh = myMesh;
                    cartesian[i, j, k].GetComponent<MeshRenderer>().material.color = Color.white;

                    cartesian[i, j, k].transform.localScale += new Vector3(50, 50, 50);
                    */

                    Vector3 pos = origin + new Vector3(i * density, j * density, k * density);
                    
                    transform.LookAt(Vector3.zero);
                    Instantiate(prefab, pos, transform.rotation);
                    //Instantiate(prefab, pos, Quaternion.identity);

                }
            }
        }

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
