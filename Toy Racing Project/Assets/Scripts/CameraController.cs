using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public variables
    public Transform m_Target;
    public float m_Height = 10f;
    public float m_Distance = 20f;
    public float m_Angle = 70f;
    public float m_SmoothSpeed = 2f;

    //Private Variables
    private Vector3 refVelocity;

    //Main Methods
    private void Start()
    {
        HandleCamera();
    }

    private void Update()
    {
        HandleCamera();
    }

    //Helper Methods
    protected virtual void HandleCamera()
    {
        if(!m_Target)
        {
            return;
        }

        //Build World Position vector
        Vector3 worldPosition = (Vector3.forward * m_Distance) + (Vector3.up * m_Height);
        //Debug.DrawLine(m_Target.position, worldPosition, Color.red);

        //Build rotated vector
        Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPosition;
        //Debug.DrawLine(m_Target.position, rotatedVector, Color.green);

        //Move position
        Vector3 flatTargetPosition = m_Target.position;
        flatTargetPosition.y = 0f;
        Vector3 finalPosition = flatTargetPosition + rotatedVector;
        //Debug.DrawLine(m_Target.position, finalPosition, Color.blue);

        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_SmoothSpeed);
        transform.LookAt(flatTargetPosition);
    }
}
