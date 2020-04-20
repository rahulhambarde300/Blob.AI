using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject robo;
    void Start()
    {
        StartCoroutine(spawnRobo());
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit;
    }

    IEnumerator spawnRobo()
    {
        while (true)
        {
            Instantiate(robo, transform.position, transform.rotation);
            yield return new WaitForSeconds(3f);
        }
        
    }
}
