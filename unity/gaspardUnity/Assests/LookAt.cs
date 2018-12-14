using UnityEngine;


public class LookAt : MonoBehaviour
{

    public Vector3 source;

    public VectorFieldMode FieldMode;


    void Start ()
    {




    }

    public Vector3 GetVectorTransform(Vector3 pos)
    {
        if (FieldMode == VectorFieldMode.Sink)
        {
            return source + transform.position;
        }
        else if (FieldMode == VectorFieldMode.Source)
        {
            return (1* pos - (source + transform.position));
        }
        return new Vector3(0, 0, 0);
    }

    void Reset()
    {
        source = new Vector3(0, 0, 0);
        FieldMode = VectorFieldMode.Constant;
        
    }


    public void SetControlPointMode(VectorFieldMode mode)
    {
        FieldMode = mode;

    }


}