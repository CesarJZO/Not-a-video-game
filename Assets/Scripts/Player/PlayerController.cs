using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movJugador : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;
    float horzontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    private void Start()
    {
        rb =GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    
    private void Update ()
    {
        MyInput();
    }

    private void FixedUpdate(){
       MovePlayer(); 
    }

    private void MyInput()
    {
        horzontalInput = Input.GetAxisRaw ("Horizontal");
        verticalInput = Input.GetAxisRaw ("Vertical");
    }

    private void MovePlayer()
    {
        //calcular el movimiento de la direccion que nos moveremos
        moveDirection=orientation.forward * verticalInput + orientation.right * horzontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    


}


