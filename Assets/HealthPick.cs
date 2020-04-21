using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerController>().currentHealth += 40;
        }
    }
}
