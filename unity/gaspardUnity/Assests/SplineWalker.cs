using UnityEngine;

public class SplineWalker : MonoBehaviour
{

    public BezierSpline spline;
    public LookAt fieldControl;

    public float duration;

    private float progress;

    public bool lookForward;
    public bool lookField;

    public SplineWalkerMode mode;
    public bool Camera;

    //Needed because the arrow asset we use is oritented wrong naturally.
    private int arrowCorrection = 90;

    private bool goingForward = true;
    private void Update()
    {
        if (goingForward)
        {
            progress += Time.deltaTime / duration;
            if (progress > 1f)
            {
                if (mode == SplineWalkerMode.Once)
                {
                    progress = 1f;
                }
                else if (mode == SplineWalkerMode.Loop)
                {
                    progress -= 1f;
                }
                else
                {
                    progress = 2f - progress;
                    goingForward = false;
                }
            }
        }
        else
        {
            progress -= Time.deltaTime / duration;
            if (progress < 0f)
            {
                progress = -progress;
                goingForward = true;
            }
        }

        Vector3 position = spline.GetPoint(progress);
        transform.localPosition = position;
        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
            transform.Rotate(0, arrowCorrection, arrowCorrection);
        }

        if (lookField)
        {
    
            if (fieldControl.FieldMode == VectorFieldMode.Sink)
            {
                
                transform.LookAt(fieldControl.GetVectorTransform(transform.position));

                if (!Camera)
                {
                    transform.Rotate(0, arrowCorrection, arrowCorrection);
                }

            }
            else if (fieldControl.FieldMode == VectorFieldMode.Source)
            {
                transform.LookAt(fieldControl.GetVectorTransform(transform.position));
                transform.Rotate(0, arrowCorrection, arrowCorrection);

            }


        }
    }
}