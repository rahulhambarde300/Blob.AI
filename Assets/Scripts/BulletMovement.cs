using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed = 60f;
    public float damage;

    Vector3 pos;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);

        //rb.velocity = new Vector2(transform.rotation.x*speed, transform.rotation.y*speed);
        
    }
    private void Update()
    {

        move();
    }


    // Update is called once per frame
    void move()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Enemy takes damage
            collision.transform.GetComponent<EnemyController>().takeDamage(damage);
            Destroy(gameObject,0f);
        }
        if(collision.gameObject.tag == "Ground")
        {
            //Activate the particles effect
            Destroy(gameObject, 0f);
        }
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<PlayerController>().takeDamage(damage);
            Destroy(gameObject, 0f);
        }
    }
}
