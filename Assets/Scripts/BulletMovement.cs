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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Enemy takes damage
            transform.Find("BloodSprayEffect").gameObject.SetActive(true);
            collision.transform.GetComponent<EnemyController>().takeDamage(damage);
            transform.Find("BloodSprayEffect").transform.SetParent(null);
            Destroy(gameObject,0f);
        }
        if(collision.gameObject.tag == "Ground")
        {
            //Activate the particles effect
            transform.Find("ElectricalSparksEffect").gameObject.SetActive(true);
            transform.Find("ElectricalSparksEffect").transform.SetParent(null);
            Destroy(gameObject, 0f);
        }
        if(collision.gameObject.tag == "Player")
        {
            transform.Find("BloodSprayEffect").gameObject.SetActive(true);
            transform.Find("BloodSprayEffect").transform.SetParent(null);
            collision.transform.GetComponent<PlayerController>().takeDamage(damage);
            Destroy(gameObject, 0f);
        }
    }
}
