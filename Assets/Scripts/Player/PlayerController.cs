using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

    public class PlayerController : MonoBehaviour{

        float speed =5f;
        public float rotationSped =50f;
        void Update(){

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movementDirection = new Vector3(horizontalInput,0,verticalInput);
        movementDirection.Normalize();
        transform.position = transform.position + movementDirection * speed *Time.deltaTime;
    if (movementDirection!= Vector3.zero){
        transform.rotation = Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(movementDirection),
        rotationSped * Time.deltaTime);

            }
        }
        
    } 
