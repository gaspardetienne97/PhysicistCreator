using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform prefab;

    void Update()
    {
        // Point the object at the world origin
        transform.LookAt(Vector3.zero);
    }
}