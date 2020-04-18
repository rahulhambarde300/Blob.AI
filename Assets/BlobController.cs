using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobController : MonoBehaviour
{
    public Transform player;
    public float followRange;
    Rigidbody rb;
    Vector2 moveVelocity;
    bool follow;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        follow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.position, transform.position) > followRange && follow)
        {
            moveVelocity = player.position - transform.position;
            moveVelocity *= new Vector2(0.5f, 0.5f);
            followPlayer();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Goto(Input.mousePosition);
            follow = follow ? false : true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Wait();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AutoAttack();
        }
    }

    private void followPlayer()
    {
        rb.velocity = moveVelocity;
    }

    private void Goto(Vector3 mousePosition)
    {
        //Blob will go to the pointed place
        Vector2 mouse = Input.mousePosition;
        //rb.MovePosition(Input.mousePosition);
        //rb.velocity = (Input.mousePosition - transform.position)* new Vector2(0.5f,0.5f);

       
            rb.position = mousePosition;

    }

    private void Wait()
    {
        //Blob will wait in current position
    }

    private void AutoAttack()
    {
        //Blob will autoattack enemies
    }
}
