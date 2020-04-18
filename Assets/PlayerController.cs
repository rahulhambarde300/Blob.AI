using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int facingDirection;
    Rigidbody rb;
    public float jumpForce;
    float distToGround;
    Vector2 force;
    // Start is called before the first frame update
    void Start()
    {
        facingDirection = 1;
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
        force = new Vector2(0, jumpForce);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            facingDirection = 1;
            Walk();
        }
        if (Input.GetKey(KeyCode.A))
        {
            facingDirection = -1;
            Walk();
        }
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.velocity = force;

        }
        
    }


    void Walk()
    {
        rb.MovePosition(transform.position + transform.right * facingDirection * Time.fixedDeltaTime);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    void Idle()
    {

    }
}
