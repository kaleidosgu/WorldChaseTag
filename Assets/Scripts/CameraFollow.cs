using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraFollow : MonoBehaviour
{
    public Transform TransTarget;

    public float DistanceLimit;

    public float DistanceCloseLimit;

    public float SpeedOfFollow;
    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
    public float smoothTime = 5f;

    private float m_fOffsetPosX;
    private float m_fOffsetPosZ;


    private Quaternion m_CameraTargetRot;
    // Start is called before the first frame update
    void Start()
    {
        m_fOffsetPosX = TransTarget.position.x - transform.position.x;
        m_fOffsetPosZ = TransTarget.position.z - transform.position.z;

        m_CameraTargetRot = transform.localRotation;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(TransTarget != null)
        //{
        //    //Vector3 vecDir = TransTarget.position - transform.position;
        //    //float fLength = Vector3.Magnitude(vecDir);

        //    //if(fLength >= DistanceLimit )
        //    //{

        //    //}
        //    //else if( fLength < DistanceCloseLimit )
        //    //{

        //    //}
        //    //else
        //    //{
        //    //    transform.Translate(vecDir.normalized * SpeedOfFollow);
        //    //}

        //    //transform.LookAt(TransTarget.position);

        //    transform.position = new Vector3(TransTarget.position.x - m_fOffsetPosX, transform.position.y, TransTarget.position.z - m_fOffsetPosZ);

        //}

        float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
        float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;
        m_CameraTargetRot *= Quaternion.Euler(0f, -xRot, 0f);

        transform.localRotation = m_CameraTargetRot;
    }

    private void FixedUpdate()
    {
        if (TransTarget != null)
        {
            transform.position = new Vector3(TransTarget.position.x - m_fOffsetPosX, transform.position.y, TransTarget.position.z - m_fOffsetPosZ);
        }
    }
}
