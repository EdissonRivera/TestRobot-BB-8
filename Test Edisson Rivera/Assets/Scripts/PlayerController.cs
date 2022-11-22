using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float InputDirectionX;
    private float InputDirectionY;


    [SerializeField]
    float movementSpeed = 5f;
    [SerializeField]
    float jumpForce = 5;

    //jumping float
    public float jumForce = 8.0f;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    //wall JumpStuf
    //public bool canWallJump = true;
    //public float wallSlidingSpeed = -0.45f;
    //public float verticalWallForce;
    //public float wallJumpTime;


    //groundCheck  //bool animator
    public float groundCheckCircle;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public bool isGrounded;

    public float playerHeight;
    public float line;

    public Rigidbody rb;
    


    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        //Variable jump Heigh
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        ApplyMovement();
        CheckEnviroment();
    }

    void CheckInput()
    {
        InputDirectionX = Input.GetAxisRaw("Horizontal");
        InputDirectionY = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }


    private void Jump()
    {
        // if (canJump)
        //{
        if (isGrounded)
            // rb.velocity = new Vector3(rb.velocity.x, jumpForce);
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            //avalableJumpsLeft--;
        //}

    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector3(movementSpeed * InputDirectionX, rb.velocity.y, movementSpeed * InputDirectionY);
    }


    private void CheckEnviroment()
    {
        //isGrounded = Physics.Linecast(groundCheck.position, groundCheckCircle, whatIsGround);
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckCircle, whatIsGround);
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        isGrounded = Physics.CheckSphere(groundCheck.position, .1f, whatIsGround);
    }

    private void OnDrawGizmos()
    {
       // Gizmos.DrawWireSphere(groundCheck.position, groundCheckCircle);
       // Gizmos.DrawLine(transform.position, new Vector3(0,line,0));
       // Gizmos.DrawWireSphere(wallCheck.position, groundCheckCircle);
    }

    
}
