using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        GameObject go1 = Instantiate(Resources.Load("Cube")) as GameObject; 

        for (int i = 0; i > 100;i++){
            GameObject go = Instantiate(go1) as GameObject;
            go.transform.position = new Vector3(0, i * 5, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
