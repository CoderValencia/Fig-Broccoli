using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public bool readyToJump;

    public float playerHeight;
    public  LayerMask ground;
    bool grounded;

    public Animator animator;
    float horizontalInput;
    float verticalInput;
    public SoundManager soundManager;


    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        soundManager = GetComponent<SoundManager>();
       
        readyToJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        PlayerInput();
        Move();
    

        if (grounded) 
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

    }
    
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            readyToJump = false; 
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }       
    }
    
    private void Move()
    {
        //on ground
        if (grounded)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);

            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
            if (verticalInput != 0 && grounded) {
                animator.SetBool("isMoving", true);
                soundManager.walkFigCement.Play(transform);


            }
            else if (verticalInput== 0 && grounded)
            {
                animator.SetBool("isMoving", false);
            }
       
  
        }
        else if (!grounded)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
           
            
            rb.freezeRotation= true;
        }
    
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.Play("FasterJump");
    }

    private void ResetJump()
    {
        readyToJump= true;
        //animator.SetBool("isJumping", false);
    }
}
