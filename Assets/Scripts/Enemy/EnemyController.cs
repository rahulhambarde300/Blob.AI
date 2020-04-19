using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float currentHealth;
    public int facingDirection;
    public bool onGround;
    private Rigidbody2D rb;
    public float jumpForce;
    public float distToGround;
    Vector2 force;
    public LayerMask lm;

    public bool playerDetected = false;
    public bool isInFireRange = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        force = new Vector2(0, jumpForce);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Find("BloodSprayEffect").gameObject.SetActive(false);
        onGround = IsGrounded();
        if (currentHealth <= 0)
        {
            Die();
        }

        if (playerDetected && !isInFireRange)
        {
            moveTowardsPlayer();
        }
        if (isInFireRange)
        {
            //transform.GetComponent<Animator>().SetBool("run", false);
            GetComponent<Animator>().enabled = false;
            GetComponentInChildren<EnemyGunController>().enabled = true;
        }

    }


    private void moveTowardsPlayer()
    {
        Transform player = FindObjectOfType<PlayerController>().transform.Find("Centre").transform.transform;
        if(transform.position.x > player.position.x)
        {
            facingDirection = -1;
        }
        else if(transform.position.x <= player.position.x)
        {
            facingDirection = 1;
            Walk();
        }
        Walk();
    }

    void Walk()
    {
        //rb.MovePosition(transform.position + transform.right * 5*facingDirection * Time.fixedDeltaTime);
        if (!onGround)
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distToGround - 3.3f, lm);
        return hit.collider != null;
    }

    public void takeDamage(float dmg)
    {
        currentHealth -= dmg;
        transform.Find("BloodSprayEffect").gameObject.SetActive(true);
    }

    private void Die()
    {
        GetComponent<Animator>().SetBool("Dead", true);
        Destroy(gameObject, 0.5f);
    }
}
