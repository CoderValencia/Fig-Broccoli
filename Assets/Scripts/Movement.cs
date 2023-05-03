using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public Transform orientation;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    public float playerHeight;
    public  LayerMask ground;
    bool grounded;

   

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    Animator anim;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();


        readyToJump = true;
    }

    // Update is called once per frame
    void Update()
    {


        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        PlayerInput();
        SpeedControl();
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
    

    void FixedUpdate()
    {
       
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            readyToJump = false;

          // rb.constraints = RigidbodyConstraints.FreezeRotation;
            Jump();
           

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        else if (readyToJump && grounded) {

            //rb.constraints = RigidbodyConstraints.FreezeRotation ;
        }
       
    }
    
    private void Move()
    {

  


        //on ground
        if (grounded)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);

            transform.Translate(Vector3.right* turnSpeed * horizontalInput * Time.deltaTime);

            Debug.Log(verticalInput);
            Debug.Log(horizontalInput);

        }
        else if (!grounded)
        {

            if (Input.GetKey(KeyCode.S))
            {
                anim.Play("MoveDown");
                moveDirection = -orientation.forward * verticalInput + orientation.right * horizontalInput;
                rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);
            }

            if (Input.GetKey(KeyCode.W))
            {
                anim.Play("MoveUp");
                moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
                rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);
            }

            if (Input.GetKey(KeyCode.A))
            {
                anim.Play("MoveLeft");
                moveDirection = new Vector3(-1, 0, 0);

                rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);

            }

            if (Input.GetKey(KeyCode.D))
            {
                anim.Play("MoveRight");
                moveDirection = new Vector3(1, 0, 0);

                rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);

            }

            //rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    private void Jump()
    {
        
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {

        readyToJump= true;
        if (grounded)
        {
            //rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        }
       

    }

}
