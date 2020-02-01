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

        if (horizontalAxis == 1 || horizontalAxis == -1)
            GetComponent<Animator>().SetBool("Walking", true);
        else
            GetComponent<Animator>().SetBool("Walking", false);

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
