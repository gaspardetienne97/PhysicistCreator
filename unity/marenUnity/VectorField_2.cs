using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorField_2 : MonoBehaviour {

// Use this for initialization
public GameObject prefab = new GameObject();
public float gridX = 5f;
public float gridY = 5f;
public float gridZ = 5f;
public float spacing = 2f;
public int startx;
public int starty;
public int startz;

void Start()
{

//Mesh myMesh = (Mesh)Resources.Load("model",typeof(Mesh)); 

//prefab.AddComponent<MeshFilter>();
//prefab.AddComponent<MeshRenderer>();
//prefab.GetComponent<MeshFilter>().sharedMesh = myMesh;
//prefab.GetComponent<MeshRenderer>().material.color = Color.white;

    for (int y = starty; y < gridY; y++) 
    {
        for (int x = startx; x < gridX; x++)
        {
            for (int z = startz; z < gridZ; z++)
            {
                Vector3 pos = new Vector3(x, z, y) * spacing;
                //Instantiate(prefab, pos, Quaternion.identity);
                Vector3 pos1 = new Vector3(0,0,0);
                Instantiate(prefab, pos, Quaternion.LookRotation(-pos1));

            }
        }
    }
} 

	// Update is called once per frame
	void Update () {
	}
}

// GameObject g = GameObject.Instantiate (prefab, transform.position, prefab.transform.rotation) as GameObject;
// g.transform.Rotate (0f, 180f, 0f);