using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject ball;

	// Use this for initialization
	void Start () {
        Instantiate(ball, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
