﻿using System;
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

    private Vector2 originalScale;
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        force = new Vector2(0, jumpForce);
        if(transform.rotation.y == 0)
        {
            facingDirection = 1;
        }
        else
        {
            facingDirection = -1;
        }
        originalScale = transform.localScale;
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

        if (playerDetected && !isInFireRange )
        {
            
            moveTowardsPlayer();
        }
        if (isInFireRange)
        {
            transform.GetComponent<Animator>().SetBool("shoot", true);
            //GetComponent<Animator>().enabled = false;
            GetComponentInChildren<EnemyGunController>().enabled = true;
        }
        else
        {
            
            //GetComponent<Animator>().enabled = false;
            try
            {
                
                GetComponentInChildren<EnemyGunController>().enabled = false;
                transform.Find("gun/SpawnPosition/muzzle flash").gameObject.SetActive(false);
                transform.GetComponent<Animator>().SetBool("shoot", false);
            }
            catch(Exception e)
            {

            }
            
        }



        if (facingDirection == -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }




    }


    private void moveTowardsPlayer()
    {
        try
        {
            Transform player = FindObjectOfType<PlayerController>().transform.Find("Centre").transform;
            if (transform.position.x > player.position.x)
            {
                facingDirection = -1;
            }
            else if (transform.position.x <= player.position.x)
            {
                facingDirection = 1;
            }
            move();
        }
        catch (Exception e)
        {

        }
        
    }

    void Walk()
    {
        //transform.GetComponent<Animator>().enabled = true;
        //rb.MovePosition(transform.position + transform.right * 5*facingDirection * Time.fixedDeltaTime);
        if (!onGround)
        {
            rb.velocity = new Vector2(20f * facingDirection, rb.velocity.y);
            transform.GetComponent<Animator>().SetBool("run", true);
        }
        else
        {
            rb.velocity = new Vector2(5f * facingDirection, 0);
            transform.GetComponent<Animator>().SetBool("run", true);
            
        }


    }
    void move()
    {
        transform.position += transform.right * 5f * Time.deltaTime;
        transform.GetComponent<Animator>().SetBool("run", true);
    }
    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distToGround - 3.3f, lm); ;
        return hit.collider != null;
    }

    public void takeDamage(float dmg)
    {
        currentHealth -= dmg;
        //transform.Find("BloodSprayEffect").gameObject.SetActive(true);
    }

    private void Die()
    {
        GetComponent<Animator>().SetBool("die", true);
        Destroy(gameObject, 0.5f);
    }
}
