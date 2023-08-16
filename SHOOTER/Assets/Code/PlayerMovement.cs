using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float groundDrag;
    public float PlayerHeight;
    
    
    bool grounded;
    public LayerMask whatIsGrounded;
    public AudioSource src;
    public AudioClip sfx1;
    
    public float movementThreshold = 0.1f; // Adjust this threshold as needed
    public float checkInterval = 0.1f; // How often to check for movement
    public Rigidbody rb;
    public Transform Orientation;
    Vector3 moveDirection;
    float horizontalInput;
    float verticalInput;
    public float MovementSpeed;
    public AudioSource src1;
    public AudioClip sfx2;
    
    public AudioSource src2;
    public AudioClip sfx3;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    public KeyCode Jumpkey = KeyCode.Space;

    
    // Start is called before the first frame update
    private void Start()
    {

        rb.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        src.clip = sfx1;
        src.Play();
    
    }
    
    // Update is called once per frame
    void Update()
    {
        
        


        // sending raycast below player 
        grounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f, whatIsGrounded);
        // adding drag if the player is on the ground
        if(grounded)
        {

            rb.drag = groundDrag;
        
        } else {
        
            rb.drag = 0;
        
        }
        // getting player input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(Jumpkey) && grounded && readyToJump)
        {
            
            readyToJump = false;
            Jump();
            Invoke(nameof(resetJump), jumpCooldown);                                                                
        
        }
    
    }
    
    private void FixedUpdate() 
    {
        // calculating wich way you want to move
        moveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;
        if (grounded)
        {
            
            rb.AddForce(moveDirection.normalized * 10f * MovementSpeed, ForceMode.Force);


            if (moveDirection.magnitude > 0.1f) // Check for movement magnitude
            {
                
                if(!src1.isPlaying)
                {
                
                    src1.clip = sfx2;
                    src1.Play();
            
                }

            }


            
        }
        
        if (!grounded)
        {
            
            rb.AddForce(moveDirection.normalized * 10f * airMultiplier, ForceMode.Force);
        
        }
    }
    
    private void Jump()
    {
        
        src2.clip = sfx3;
        src2.Play();
        // setting the y velocity to zero
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    
    }
    private void resetJump()
    {

        readyToJump = true;

    }






}


