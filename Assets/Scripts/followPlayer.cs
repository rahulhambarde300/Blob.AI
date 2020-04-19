using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 forward = player.transform.forward * 10.0f;
        Vector3 needPos = player.transform.position - forward;
        transform.position = Vector3.SmoothDamp(transform.position, needPos,
                                                ref velocity, 0.05f);
        transform.LookAt(player.transform);
        transform.rotation = player.transform.rotation;
    }
}
