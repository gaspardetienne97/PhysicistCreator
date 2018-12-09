using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

// Use this for initialization
public GameObject prefab = new GameObject();
public float gridX = 5f;
public float gridY = 5f;
public float gridZ = 5f;
public float spacing = 2f;


void Start()
{

//Mesh myMesh = (Mesh)Resources.Load("model",typeof(Mesh)); 

//prefab.AddComponent<MeshFilter>();
//prefab.AddComponent<MeshRenderer>();
//prefab.GetComponent<MeshFilter>().sharedMesh = myMesh;
//prefab.GetComponent<MeshRenderer>().material.color = Color.white;

    for (int y = 0; y < gridY; y++) 
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 pos = new Vector3(x, z, y) * spacing;
                Instantiate(prefab, pos, Quaternion.identity);
                
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