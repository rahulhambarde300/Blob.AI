using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    public Rigidbody2D bullet;
    bool revert = false;
    Transform spawnPosition;
    public float timeBetweenShot;
    public float shotTime;
    public float bulletSpeed;

    public float accuracy;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.Find("SpawnPosition");
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Animator>().enabled = false;
        if (FindObjectOfType<PlayerController>() != null)
        {
            Vector2 direction = FindObjectOfType<PlayerController>().transform.Find("Centre").transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


            if (direction.x < 0 && !revert)
            {
                transform.localScale = transform.localScale * new Vector2(1, -1);
                revert = true;
            }
            else if (direction.x > 0 && revert)
            {
                transform.localScale = transform.localScale * new Vector2(1, -1);
                revert = false;
            }
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        }
        




            if (Time.time >= shotTime)
            {
                transform.Find("SpawnPosition/MuzzleFlashEffect").gameObject.SetActive(true);
                Vector3 acc = new Vector3(0, 0, Random.Range(-accuracy, accuracy));
                Rigidbody2D bulletInstance = Instantiate(bullet, spawnPosition.position, spawnPosition.rotation * Quaternion.Euler(acc)) as Rigidbody2D;
                //bulletInstance.velocity = (new Vector2(direction.x, direction.y).normalized) *  new Vector2(bulletSpeed,bulletSpeed);
                shotTime = Time.time + timeBetweenShot;
                bulletInstance.GetComponent<BulletMovement>().damage = damage;
                //GetComponent<Animator>().enabled = true;
                Destroy(bulletInstance.gameObject, 4f);
            }




    }
}
