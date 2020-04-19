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

    public float MaxHealth = 100f;
    public float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        facingDirection = -1;
        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        force = new Vector2(0, jumpForce);
        currentHealth = MaxHealth;
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
        

        onGround = IsGrounded();
        if (currentHealth <= 0)
        {
            Die();
        }

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

    public void takeDamage(float dmg)
    {
        currentHealth -= dmg;
    }

    private void Die()
    {
        //GetComponent<Animator>().SetBool("Dead", true);
        Destroy(gameObject, 0.5f);
    }
}
