using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour{

    private Rigidbody2D myRigidbody;
    
    public int speed;
    public int jumpForce;

    private bool facingRight;

    public Transform onGroundCheck;
    public float groundChRadius;
    public LayerMask whatIsAGround;
    private bool onGround;
    private bool doubleJump;

    private Animator anim;


    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        facingRight = true;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(onGroundCheck.position, groundChRadius, whatIsAGround);
    }

    void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Movement(horizontal);

        Flip(horizontal);

        if (onGround)
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump") && onGround)
        {
            Jump();
        }

        if (Input.GetButtonDown("Jump") && !doubleJump && !onGround)
        {
            Jump();
            doubleJump = true;
        }

        anim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        anim.SetFloat("Jump", Mathf.Abs(myRigidbody.velocity.y));
    }

    private void Movement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal * speed, myRigidbody.velocity.y);
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;

            scale.x *= -1;

            transform.localScale = scale;
        }
    }

    public void Jump()
    {
        myRigidbody.AddForce(Vector2.up * jumpForce);
    }
}
