using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool launched;
    public Rigidbody cameraRigidBody;
    void Start()
    {
        cameraRigidBody = GetComponent<Rigidbody>();
        launched = false;
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            launched = true;
        }
        cameraMethod(launched);
    }
    void cameraMethod(bool boolian)
    {
        if (boolian && !Mover.exit)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        if(Mover.exit)
        {
            cameraRigidBody.velocity = new Vector3 (0f, 0f ,0f);
        }
    }
}