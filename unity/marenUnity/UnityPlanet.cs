using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityPlanet : MonoBehaviour
{

    // orbits around a "star" at the origin with fixed mass
    public float Mass = 1000f;
    public float MG = 980f;

    // Use this for initialization
    void Start()
    {
        float initV = Mathf.Sqrt(Mass/ transform.position.magnitude);
        GetComponent<Rigidbody>().velocity = new Vector3(0, initV, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rad = Vector3.Magnitude(transform.position);
        float totalForce = -(MG) / (rad * rad);
        Vector3 force = (transform.position).normalized * totalForce;
        GetComponent<Rigidbody>().AddForce(force);
    }
}