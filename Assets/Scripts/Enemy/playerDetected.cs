using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetected : MonoBehaviour
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
        if(collision.transform.tag == "Player")
        {
            //Player Detected
            transform.root.GetComponent<EnemyController>().playerDetected = true;
            Debug.Log("Hello doctor");

        }
    }
}
