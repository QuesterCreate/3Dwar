using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public int rotateSpeed = 300;


    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
       
        if(Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }


    }
}
