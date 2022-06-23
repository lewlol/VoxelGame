using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    bool isGrounded;
    public GameObject cam;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    public float horizontalInput;
    public float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        Jump();
        Sprinting();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * movementSpeed;
        }        
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = transform.up * jumpForce;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void Sprinting()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 10f;
        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = 6f;
        }
    }
}
