using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementControl : MonoBehaviour
{
    public MeshRenderer meshRender;
    public float displacementAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displacementAmount = Mathf.Lerp(displacementAmount, 0, Time.deltaTime);
        meshRender.material.SetFloat("_Amount", displacementAmount);
        /*
        if (Input.GetButtonDown("Jump"))
        {
            displacementAmount = 1f;
        }
        displacementAmount = 0.1f;*/
    }
}
