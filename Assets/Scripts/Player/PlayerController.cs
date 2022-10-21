using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamaraJugado : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orientacion;

    float xRotacion;
    float yRotacion;
    
    private void Start(){
        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible= false;
    }

    private void Update(){
        float mouseX=Input.GetAxis("Mouse X")*Time.deltaTime *sensX;
        float mouseY=Input.GetAxis("Mouse Y")*Time.deltaTime *sensY;

        yRotacion += mouseX;
        xRotacion -= mouseY;
        xRotacion = Mathf.Clamp(xRotacion, -96f,-96f);

        //rotacion de la camara y orientacion 

        transform.rotation= Quaternion.Euler(xRotacion, yRotacion, 0);
        orientacion.rotation =Quaternion.Euler(0, yRotacion, 0);    
         
    }


}


