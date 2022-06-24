using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotSpeed = 1.5f;
    private float _rotY;
    private Vector3 _offset;
    private Vector3 ogPos;
    private Quaternion ogRot;

    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        Rotate();
        Zooming();
        MaxZoom();
        ResetZoom();
    }

    void Rotate()
    {
        _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;

        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            target.transform.rotation = rotation;
        }
        
    }
    void Zooming()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            gameObject.GetComponent<Camera>().fieldOfView -= 5;
        } else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            gameObject.GetComponent<Camera>().fieldOfView += 5;
        }
        
    }
    void MaxZoom()
    {
        if(gameObject.GetComponent<Camera>().fieldOfView >= 100)
        {
            gameObject.GetComponent<Camera>().fieldOfView = 100;
        }
        if(gameObject.GetComponent<Camera>().fieldOfView <= 30)
        {
            gameObject.GetComponent<Camera>().fieldOfView = 30;
        }
    }

    void ResetZoom()
    {
        if (Input.GetMouseButtonDown(2))
        {
            gameObject.GetComponent<Camera>().fieldOfView = 60;
        }
    }
}
