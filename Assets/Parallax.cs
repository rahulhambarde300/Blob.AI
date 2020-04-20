using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallax;

    public void moveBackground(int facingDirection)
    {
        transform.position = new Vector3( transform.position.x - facingDirection * Time.deltaTime * parallax,transform.position.y,transform.position.z);
    }
}
