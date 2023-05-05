using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestingMovement : MonoBehaviour
{

    public float speed = 5f;
    public float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    private Rigidbody rb;

  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
        // Player Input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical" );

        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Rotate the vehicle left and right (horizontal) -- .up changes Y axis
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

    }
}
