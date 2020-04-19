using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int facingDirection;
    Rigidbody2D rb;
    public float jumpForce;
    public float distToGround;
    Vector2 force;
    public bool onGround;
    public LayerMask lm;


    public float speed = 5f;
    bool coroutineUse = false;

    public Animation running;
    public Animation Idle;

    // Start is called before the first frame update
    void Start()
    {
        facingDirection = -1;
        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        force = new Vector2(0, jumpForce);
    }



    // Update is called once per frame
    void Update()
    {
        onGround = IsGrounded();
        if (Input.GetKey(KeyCode.D))
        {
            if (facingDirection != 1)
            {
                transform.localScale = transform.localScale * new Vector2(-1, 1);
            }
            facingDirection = 1;
            Walk();
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (facingDirection != -1)
            {
                transform.localScale = transform.localScale * new Vector2(-1, 1);
            }
            facingDirection = -1;
            Walk();

        }
        else
        {
            transform.GetComponent<Animator>().SetBool("run", false);
        }
        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            
            rb.velocity = force;

        }
        /*
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
        */
        


    }


    void Walk()
    {
        //rb.MovePosition(transform.position + transform.right * 5*facingDirection * Time.fixedDeltaTime);
        if(!onGround)
        {
            rb.velocity = new Vector2(3f * facingDirection, rb.velocity.y);
            transform.GetComponent<Animator>().SetBool("run", true);
        }
        else
        {
            rb.velocity = new Vector2(5f * facingDirection, rb.velocity.y);
            transform.GetComponent<Animator>().SetBool("run", true);
        }
        

    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distToGround -3.3f,lm);
        return hit.collider != null;
    }
}
