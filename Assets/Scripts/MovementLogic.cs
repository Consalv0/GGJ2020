using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementLogic : MonoBehaviour
{
    public float xMaxInputVelocity;
	public float damping = 0.1F;
    private new Rigidbody2D rigidbody;
    private float currentDamping = 0;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float xMovement = Mathf.Sign(horizontalAxis) * Mathf.Ceil(Mathf.Abs(horizontalAxis));
        Vector2 currentVelocity = rigidbody.velocity;
        if(horizontalAxis!=0)
        GetComponent<Animator>().SetBool("Hide",false);
		GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(horizontalAxis));

		if (horizontalAxis <= -0.01)
			transform.localScale = new Vector3(-1, 1, 1);
		else if(horizontalAxis>=0.01)
			transform.localScale = new Vector3(1, 1, 1);

		if (Mathf.Abs(xMovement) >= 0.1F)
        {
            currentDamping = 1;
        }
        else
        {
            currentDamping -= Time.deltaTime * damping;
            currentDamping = Mathf.Clamp01(currentDamping);
        }



        float maxVelocity = currentDamping * Mathf.Abs(xMaxInputVelocity);
        float targetXVelocity = Mathf.Clamp(currentVelocity.x + xMovement, -maxVelocity, maxVelocity);

        rigidbody.velocity = new Vector2(targetXVelocity, currentVelocity.y);
    }
}
