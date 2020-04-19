using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int facingDirection;
    Rigidbody2D rb;
    public float jumpForce;
    float distToGround;
    Vector2 force;
    public bool onGround;
    public LayerMask lm;

    //public GameObject bullet;
    public Transform spawnPosition;
    public float speed = 5f;
    bool coroutineUse = false;
    public GameObject shot;
    public float Damage = 10;
    public float fireRate = 0;
    float timeToFire = 0;

    public GameObject blob;
    public Sprite gunSprite;
    // Start is called before the first frame update
    void Start()
    {
        facingDirection = 1;
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
            facingDirection = 1;
            Walk();
        }
        if (Input.GetKey(KeyCode.A))
        {
            facingDirection = -1;
            Walk();
        }
        if (Input.GetKeyDown(KeyCode.W))
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
        if (Input.GetButtonDown("Jump"))
        {
            blob.GetComponent<BlobController>().changeShape(gunSprite);
        }


    }


    void Walk()
    {
        //rb.MovePosition(transform.position + transform.right * 5*facingDirection * Time.fixedDeltaTime);
        rb.AddForce(transform.right * facingDirection * speed);

    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.1f,lm);
        return hit.collider != null;
    }

    void Idle()
    {

    }

    void Shoot()
    {
        Instantiate(shot, spawnPosition.position,spawnPosition.rotation);
        Vector2 firePointPosition = new Vector2(spawnPosition.position.x,spawnPosition.position.y);
        
    }
}
