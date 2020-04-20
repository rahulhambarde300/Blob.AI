using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "weapon")
        {
            pickup_Weapon();
            Destroy(collision.gameObject, 0.2f);
        }
        else if(collision.gameObject.tag =="pickup")
        {
            pickup();
            Destroy(collision.gameObject, 0.2f);
        }
    }

    void pickup_Weapon()
    {
        FindObjectOfType<BlobController>().maxCount += 1;
    }

    void pickup()
    {

    }
}
