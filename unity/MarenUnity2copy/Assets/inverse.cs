using UnityEngine;

public class inverse : MonoBehaviour
{
    // Sets this transform to have the opposite rotation of the target
    public Transform prefab;
    void Update()
    {
        transform.rotation = Quaternion.Inverse(prefab.rotation);
    }
}