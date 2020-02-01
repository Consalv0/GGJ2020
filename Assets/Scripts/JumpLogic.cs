using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLogic : MonoBehaviour
{
	public bool isGrounded;

	[Range(1, 100)]
	public float jumpVelocity;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	public float maxVelocityY;
	public float jumpTime;

	private bool isJumping;
	private float jumpTimeCounter;

	Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
		rb2D = GetComponent<Rigidbody2D>();
		jumpTimeCounter = jumpTime;
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == ("ground") && isGrounded == false){
			isGrounded = true;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			isJumping = true;
			rb2D.velocity = Vector2.up * jumpVelocity;
			isGrounded = false;
			
			jumpTimeCounter = jumpTime;

		}

		if (rb2D.velocity.y < 0)
		{
			rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (rb2D.velocity.y > 0 && Input.GetKeyUp(KeyCode.Space))
		{
			rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.Space) && isJumping==true)
		{
			if (jumpTimeCounter > 0)
			{
				rb2D.velocity = Vector2.up * jumpVelocity;
				jumpTimeCounter -= Time.deltaTime;
			}
			else isJumping = false;
			
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			isJumping = false;
		}
	}
}
