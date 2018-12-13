using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform prefab;
    //var Vector3 = (prefab.position.x, prefab.position.y, prefab.position.z);

    void Update()
    {
        // Point the object at the world origin
        transform.LookAt(Vector3.zero);
        //transform.LookAt(Vector3.back);
    }
}