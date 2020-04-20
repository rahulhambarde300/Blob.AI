using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public LayerMask notToHit;
    private void Update()
    {
        shoot();
    }
    void shoot()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePoint = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(firePoint, mousePosition - firePoint, 100, notToHit);
        Debug.DrawRay(firePoint, (mousePosition-firePoint)*100,Color.cyan);
    }
}
