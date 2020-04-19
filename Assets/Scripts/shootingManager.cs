using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingManager : MonoBehaviour
{
    Vector2 mousePosition;
    public Rigidbody2D bullet;
    bool revert = false;
    Transform spawnPosition;
    public float timeBetweenShot;
    public float shotTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.Find("SpawnPosition");
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;


        if(direction.x < 0 && !revert)
        {
            transform.localScale = transform.localScale * new Vector2(1, -1);
            revert = true;
        }else if(direction.x > 0 && revert)
        {
            transform.localScale = transform.localScale * new Vector2(1, -1);
            revert = false;
        }
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
        //...instantiating the rocket
       
        if (Input.GetButton("Fire1"))
        {
            if(Time.time >= shotTime)
            {
                Rigidbody2D bulletInstance = Instantiate(bullet, spawnPosition.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(direction.x * 10f, direction.y * 10f);
                shotTime = Time.time + timeBetweenShot;
            }

            

        }
        
    }
}
