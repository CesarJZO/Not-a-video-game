using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

    public class Controls : MonoBehaviour{
        
    Rigidbody rb;
    public float moveSpeed = 5;
    public float runSpeed = 8;

    float h;
    float v;
    bool floorDetected = false;
    bool isJump = false;
    public float jumpForce = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        Move();
    }

    void Move()
    {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);

        if (Input.GetButton("Fire3"))
            transform.Translate(direction * runSpeed * Time.deltaTime);
        else
            transform.Translate(direction * moveSpeed * Time.deltaTime);

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
