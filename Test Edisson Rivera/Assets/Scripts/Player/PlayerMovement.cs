using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    internal float InputDirectionX;
    internal float InputDirectionY;

    [SerializeField] internal float movementSpeed = 6f;
    [SerializeField] internal float jumpForce = 5f;

    float groundCheckCircle = 1;
    [SerializeField] LayerMask ground;
    internal bool jump;
    Rigidbody rb;
    Transform orientation;
    Vector3 moveDirection;
    [SerializeField] private Vector3 lookDir;
    [SerializeField] private Transform meshPlayer;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        orientation = GetComponent<Transform>();
    }

    private void Update()
    {
        ApplyMovement();
        SpeedControl();

        if (jump)
            Jump();
    }
    void Jump()
    {
        if (IsGrounded())
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void ApplyMovement()
    {
        moveDirection = orientation.forward * InputDirectionY + orientation.right * InputDirectionX;
        //rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        //rb.velocity = moveDirection.normalized * movementSpeed;

        rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);


        if (InputDirectionX != 0 || InputDirectionY != 0)
        {
            if (InputDirectionX >= 0.2 || InputDirectionY >= 0.2 || InputDirectionX <= -0.2 || InputDirectionY <= -0.2)
            {
                    lookDir = new Vector3(moveDirection.x, 0, moveDirection.z);
                    meshPlayer.rotation = Quaternion.LookRotation(lookDir);
            }
        }
        //rb.velocity = new Vector3(InputDirectionX * movementSpeed, rb.velocity.y, InputDirectionY * movementSpeed);


    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, groundCheckCircle, ground);
    }

}
