using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

    public class PlayerController : MonoBehaviour{

        float speed =5f;
        void Update(){

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movementDirection = new Vector3(horizontalInput,0,verticalInput);
        transform.position = transform.position + movementDirection * speed *Time.deltaTime;
        }
        
    } 
