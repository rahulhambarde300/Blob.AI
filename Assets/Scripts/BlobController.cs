using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobController : MonoBehaviour
{
    public Transform player;
    public float followRange;
    Rigidbody2D rb;
    Vector2 moveVelocity;
    bool follow;
    Vector2 restPosition;
    int facingDirection;
    float speed = 1.5f;
    Vector2 pos;
    bool goTo;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        follow = true;
        index = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
            facingDirection = player.GetComponent<PlayerController>().facingDirection;
        
       
        if (Input.GetMouseButtonDown(1))
        {
            if (follow)
            {
                //Goto();
                pos = Input.mousePosition;
                pos = Camera.main.ScreenToWorldPoint(pos);
                goTo = true;
            }
            else
            {
                follow = true;
                goTo = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Wait();
        }



        if (goTo){       
            transform.position = Vector2.Lerp(transform.position, pos, speed * Time.deltaTime);
            follow = false;

        }

        if (Input.GetButtonDown("Jump"))
        {
            changeShape();
        }


    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 toTarget = (Vector2)player.position - (Vector2)transform.position - new Vector2(facingDirection * 2, -4);
            if (follow)
            {
                transform.Translate(toTarget * speed * Time.deltaTime);
            }

        }

    }


    private void Wait()
    {
        //Blob will wait in current position
        follow = follow ? false : true;
    }

    public void changeShape()
    {
        int childCount = transform.childCount;
        transform.GetChild(index).gameObject.SetActive(false);
        //Set current weapon as invisible
        index += 1;
        index %= childCount;
        //Set next weapon as visible
        transform.GetChild(index).gameObject.SetActive(true);

        
    }



}
