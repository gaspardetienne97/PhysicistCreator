using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]

public class VectorField : MonoBehaviour {


    public int density = 10;
    public int scale = 10;

    public int xrange = 100;
    public int yrange = 100;
    public int zrange = 100;

    public Vector3 origin;
    public Vector3 xend;
    public Vector3 yend;
    public Vector3 zend;

    public LookAt fieldControl;

    private int arrowCorrection = 90;
    

    //private GameObject[,,] cartesian = new GameObject[(int)xrange / density, (int)yrange / density, (int)zrange / density];


    public LineRenderer curveRenderer;
    public List<LineRenderer> cartesianLines;

    // Use this for initialization
    void Start () {

        if (!curveRenderer)
        {
            curveRenderer = GetComponent<LineRenderer>();
            //cartesianLines = new List<LineRenderer>();



        }

        //LineRenderer lRend1 = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
        //lRend1.SetVertexCount(2);
        //lRend1.SetPosition(0, origin+transform.position);
        //lRend1.SetPosition(1, xend + transform.position);
        //lRend1.material.color = Color.white;
        //lRend1.enabled = true;
        //cartesianLines.Add(lRend1);


        //LineRenderer lRend2 = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
        //lRend2.SetVertexCount(2);
        //lRend2.SetPosition(0, origin + transform.position);
        //lRend2.SetPosition(1, yend + transform.position);
        //lRend2.material.color = Color.white;
        //lRend2.enabled = true;
        //cartesianLines.Add(lRend2);


        //LineRenderer lRend3 = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
        //lRend3.SetVertexCount(2);
        //lRend3.SetPosition(0, origin + transform.position);
        //lRend3.SetPosition(1, zend + transform.position);
        //lRend3.material.color = Color.white;
        //lRend3.enabled = true;
        //cartesianLines.Add(lRend3);

        //cartesian = new GameObject[(int)xrange / density, (int)yrange / density, (int)zrange / density];
        //Material material = Resources.Load("ArrowAsset/materials", typeof(Material)) as Material;
        Mesh myMesh = (Mesh)Resources.Load("ArrowAsset/CorrectedPivotArrow", typeof(Mesh));

        GameObject prefab = new GameObject("Arrows");
        prefab.transform.localScale += new Vector3(scale, scale, scale);
        prefab.AddComponent<MeshFilter>();
        prefab.AddComponent<MeshRenderer>();
        prefab.GetComponent<MeshFilter>().sharedMesh = myMesh;
        //prefab.GetComponent<MeshRenderer>().material.color = Color.white;
        Material myMaterial = (Material)Resources.Load("ArrowAsset/MyWhite", typeof(Material));
        prefab.GetComponent<MeshRenderer>().material = myMaterial;


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

                    GameObject arrow;

                    Vector3 pos = origin + new Vector3(i * density, j * density, k * density) + transform.position;

                    if (fieldControl.FieldMode == VectorFieldMode.Sink)
                    {
                        arrow = (Instantiate(prefab, pos, Quaternion.identity)) as GameObject;
                        arrow.transform.LookAt(fieldControl.GetVectorTransform(transform.position));
                        arrow.transform.Rotate(0, arrowCorrection, arrowCorrection);


                    }
                    else if (fieldControl.FieldMode == VectorFieldMode.Source)
                    {
                        arrow = (Instantiate(prefab, pos, Quaternion.identity)) as GameObject;
                        arrow.transform.LookAt(fieldControl.GetVectorTransform(transform.position));
                        arrow.transform.Rotate(0, arrowCorrection, arrowCorrection);

                    }
                    else
                    {
                        arrow = Instantiate(prefab, pos, Quaternion.identity) as GameObject;

                    }
                    arrow = null;

                }
            }
        }

    }

    public Vector3 GetControlPoint(int index)
    {
        if (index == 0) {
            return origin;
        } else if (index == 1) {
            return xend;
        } else if (index == 2)
        {
            return yend;
        } else
        {
            return zend;
        }
        
    }

    public void SetControlPoint(int index, Vector3 point)
    {
        if (index == 0)
        {
            origin = point;
        }
        else if (index == 1)
        {
            xend = point;
        }
        else if (index == 2)
        {
            yend = point;
        }
        else
        {
            zend = point;
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
