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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        follow = true;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AutoAttack();
        }

        if (goTo){       
            transform.position = Vector2.Lerp(transform.position, pos, speed * Time.deltaTime);
            follow = false;

        }

        

    }

    private void FixedUpdate()
    {
        Vector2 toTarget = (Vector2)player.position - (Vector2)transform.position - new Vector2(facingDirection,-1);
        
        if (follow)
        {
            transform.Translate(toTarget * speed * Time.deltaTime);
            transform.parent = player;
        }
    }




    private void Wait()
    {
        //Blob will wait in current position
        follow = follow ? false : true;
    }

    public void changeShape(Sprite weapon)
    {
        //GetComponent<SpriteRenderer>().sprite = weapon;
        //GetComponent<shootingManager>().enabled = true;
        if(player.Find("pistol").gameObject != null){
            player.Find("pistol").gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }

    private void AutoAttack()
    {
        //Blob will autoattack enemies
    }

}
