using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public GameObject thePlayer;
    public bool isRunning;
    public float horizontalMove;
    public float verticalMove;
    private Animator anim;
    public float horiSpeed=150f;
    public float vertiSpeed=8f;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Run();
            horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * horiSpeed;
            verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * vertiSpeed;
            isRunning = true;
            transform.Rotate(0, horizontalMove, 0);
            transform.Translate(0, 0, verticalMove);
        }
        else
        {
            Idle();
            isRunning = false;
        }
       
    }
 private void Idle()
    {
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

   
}






/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public GameObject thePlayer;
    public bool isRunning;
    public float horizontalMove;
    public float verticalMove;
    private Animator anim;
    public float horiSpeed = 150f;
    public float vertiSpeed = 8f;
    private Rigidbody rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Run();
            horizontalMove = Input.GetAxis("Horizontal") * horiSpeed;
            verticalMove = Input.GetAxis("Vertical") * vertiSpeed;
            isRunning = true;
            Vector3 movement = new Vector3(0, 0, verticalMove * Time.deltaTime);
            rb.MovePosition(transform.position + transform.TransformDirection(movement));
            transform.Rotate(0, horizontalMove * Time.deltaTime, 0);
        }
        else
        {
            Idle();
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        // Implement your jump logic here
    }
}
*/




/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public GameObject thePlayer;
    public bool isRunning;
    public float horizontalMove;
    public float verticalMove;
    private Animator anim;
    public float horiSpeed = 150f;
    public float vertiSpeed = 8f;
    private Rigidbody rb;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    private bool isGrounded;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // Set to Continuous for better collision handling
    }

    private void Update()
    {
        GroundCheck(); // Check if the player is grounded

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Run();
            horizontalMove = Input.GetAxis("Horizontal") * horiSpeed;
            verticalMove = Input.GetAxis("Vertical") * vertiSpeed;
            isRunning = true;
            Vector3 movement = new Vector3(0, 0, verticalMove * Time.deltaTime);
            rb.MovePosition(transform.position + transform.TransformDirection(movement));
            transform.Rotate(0, horizontalMove * Time.deltaTime, 0);
        }
        else
        {
            Idle();
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }

    private void GroundCheck()
    {
        // Check if the player is grounded by casting a ray downwards
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}
*/