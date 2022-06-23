using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotSpeed = 1.5f;
    private float _rotY;
    private Vector3 _offset;
    private Vector3 ogPos;
    private Quaternion ogRot;
    private float mouseSpeed;
    bool dontRotate;

    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        ogPos = transform.position;
        ogRot = transform.rotation;
    }

    void LateUpdate()
    {
        Rotate();
        Zooming();
        MaxZooming();
    }

    void Rotate()
    {
        _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;

        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Doesnt Rotate With Cam -- Lets the Player see the front of their Character
        }
        else
        {
            target.transform.rotation = rotation;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.position = ogPos;
            transform.rotation = ogRot;
        }
    }

    void Zooming()
    {
        mouseSpeed = Input.GetAxis("Mouse ScrollWheel");

        if (mouseSpeed > 0)
        {
            gameObject.GetComponent<Camera>().fieldOfView -= 5f;
        }else if(mouseSpeed < 0)
        {
            gameObject.GetComponent<Camera>().fieldOfView += 5f;
        }

        if (Input.GetMouseButtonDown(2))
        {
            gameObject.GetComponent<Camera>().fieldOfView = 60;
        }
    }

    void MaxZooming()
    {
        if(gameObject.GetComponent<Camera>().fieldOfView < 30)
        {
            gameObject.GetComponent<Camera>().fieldOfView = 30;
        }
        if(gameObject.GetComponent<Camera>().fieldOfView > 100)
        {
            gameObject.GetComponent<Camera>().fieldOfView = 100;
        }
    }
}
