using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float InputDirectionX;
    private float InputDirectionY;
    public Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckCircle = 1;
    [SerializeField] LayerMask ground;


    public Transform sphere;
    public Vector3 data;
    //[SerializeField] AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // float horizontalInput = Input.GetAxis("Horizontal");
       // float verticalInput = Input.GetAxis("Vertical");

       // rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
       ////transform.position = rb.transform.position;
        /*if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }*/

        CheckInput();
        ApplyMovement();
        //sphere.rotation = new Quaternion(sphere.rotation.x + InputDirectionX,sphere.rotation.y,sphere.rotation.z + InputDirectionX, 0);
       // sphere.transform.Rotate(data * Time.deltaTime);
    }


    void CheckInput()
    {
        InputDirectionX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        InputDirectionY = Input.GetAxisRaw("Vertical") * movementSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    private void ApplyMovement()
    {
        rb.velocity = new Vector3(InputDirectionX, rb.velocity.y,InputDirectionY);
        //data = rb.velocity / movementSpeed;
       // sphere.transform.Rotate(rb.velocity.z,rb.velocity.y,rb.velocity.x);

    }

    void Jump()
    {
        if(IsGrounded())
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

        //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        //jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }*/
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundCheckCircle, ground);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckCircle);
    }
}
