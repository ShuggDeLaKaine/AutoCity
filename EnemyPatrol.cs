using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool movingRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsAWall;
	private bool hitAWall;

	private bool notGrounded;
	public Transform groundCheck;

    public int damageToGive;
	
	private Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start ()
    {
		myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		hitAWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsAWall);

		notGrounded = Physics2D.OverlapCircle (groundCheck.position, wallCheckRadius, whatIsAWall);

		if (hitAWall || !notGrounded)
			movingRight = !movingRight;

		if (movingRight) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			myRigidbody2D.velocity = new Vector2 (moveSpeed, myRigidbody2D.velocity.y);
		} else {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			myRigidbody2D.velocity = new Vector2(-moveSpeed, myRigidbody2D.velocity.y);
		}
	}
    
}
