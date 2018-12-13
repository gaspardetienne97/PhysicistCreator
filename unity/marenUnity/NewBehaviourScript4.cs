//In this example your GameObject rotates towards the position of the mouse

using UnityEngine;

public class Example2 : MonoBehaviour
{
    Quaternion m_MyQuaternion;
    float m_Speed = 1.0f;
    Vector3 m_MousePosition;

    void Start()
    {
        m_MyQuaternion = new Quaternion();
    }

    void Update()
    {
        //Fetch the mouse's position
        m_MousePosition = Input.mousePosition;
        //Fix how far into the scene the mouse should be
        m_MousePosition.z = 50.0f;
        //Transform the mouse position into world space
        m_MousePosition = Camera.main.ScreenToWorldPoint(m_MousePosition);

        //Set the Quaternion rotation from the GameObject's position to the mouse position
        m_MyQuaternion.SetFromToRotation(transform.position, m_MousePosition);
        //Move the GameObject towards the mouse position
        transform.position = Vector3.Lerp(transform.position, m_MousePosition, m_Speed * Time.deltaTime);
        //Rotate the GameObject towards the mouse position
        transform.rotation = m_MyQuaternion * transform.rotation;
    }
}