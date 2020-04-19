using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed = 10f;
    public float damage;

    Vector3 pos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            //Enemy takes damage
            //collision.transform.GetComponent<EnemyController>().takeDamage(damage);
            Destroy(gameObject,0.2f);
        }
    }
}
