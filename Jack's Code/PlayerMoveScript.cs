using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask isground;
    bool isItGrounded;

    public Transform orientation;

    float xInput;
    float yInput;

    Vector3 moveDirect;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the rigidbody and stops it rotating
        rb = GetComponent<Rigidbody>(); 
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Listens for input
        MyInput();

        // Ground Check
        isItGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isground);

        // Apply drag
        if (isItGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        // Stops the player going too fast
        SpeedControl();

    }

    private void MyInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Calculate the movement direction
        moveDirect = orientation.forward * yInput + orientation.right * xInput;

        rb.AddForce(moveDirect.normalized * speed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        // Defined the flat velocity variable
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Limits the velocity i it exceeds maximum
        if (flatVel.magnitude > speed)
        {
            Vector3 limitVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }
}
