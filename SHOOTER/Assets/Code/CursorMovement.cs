using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{

    public Rigidbody rb;
    public Transform Orientation;
    public Camera fpscam;
    
    public float MouseSenseX;
    public float MouseSenseY;

    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    private void Update()
    {
        // it is getting the mouse input based on the position of the mosue
        float mouseX = Input.GetAxisRaw("Mouse X") * MouseSenseX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * MouseSenseX * Time.deltaTime;
        
        // for diagonal mouse input
        xRotation -= mouseY;
        yRotation += mouseX;
        
        // clamping the rotation to 90 degrees so player cant look back at himself
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //Rotating the player based on cursor position using unity's built in rotation system 
        //called Quanternions.
        
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        
    
    

    }




}
