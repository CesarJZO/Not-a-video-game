using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 2f;
    Vector3 velocity;
    
    public float rotationSped = 30f;
    bool floorDetected = false;
    bool isJump = false;
    public float jumpForce = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        
        velocity = new Vector3
        {
            x = movementDirection.x * speed,
            y = rb.velocity.y,
            z = movementDirection.z * speed
        };

        if (movementDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(movementDirection),
            rotationSped * Time.deltaTime);
        }

        Vector3 floor = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, floor, 1.03f))
        {
            floorDetected = true;
            //print("Contacto con el suelo");
        }
        else
        {
            floorDetected = false;
            //print("No hay contacto con el suelo");
        }

        isJump = Input.GetButtonDown("Jump");
    
        if (isJump && floorDetected)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

}
