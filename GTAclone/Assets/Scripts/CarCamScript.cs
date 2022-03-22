using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamScript : MonoBehaviour
{
    float MouseSensivity = 10;
    float xRotation = 0;
    float yRotation = 0;
    public Transform CamTrans;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*MouseSensivity; 
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensivity; 

        xRotation = xRotation - mouseY;
        yRotation = yRotation - mouseX;

        // = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(0,yRotation , 0);
        CamTrans.Rotate(Vector3.right * mouseY);
    }
}
