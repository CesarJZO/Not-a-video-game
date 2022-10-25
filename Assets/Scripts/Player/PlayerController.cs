using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

    public class PlayerController : MonoBehaviour{
        Rigidbody rb;
        float speed = 2f;
        public float rotationSped =30f;
        bool floorDetected = false;
        bool isJump = false;
        public float jumpForce = 5.0f;
        
        void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
        
        void Update(){

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movementDirection = new Vector3(horizontalInput,0,verticalInput);
        movementDirection.Normalize();
        transform.position = transform.position + movementDirection * speed *Time.deltaTime;
        if (movementDirection != Vector3.zero){
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
