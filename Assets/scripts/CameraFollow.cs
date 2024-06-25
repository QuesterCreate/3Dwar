using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float moveSmoothness;
    public float rotSmoothness;


    public Vector3 moveOffset;
    public Vector3 rotOffset;

    public Transform objectTarget;

    void FixedUpdate()
    {



        HandleMovement();
        HandleRotation();
    }






    void HandleMovement()
    {

        Vector3 targetPos = new Vector3();
        targetPos = objectTarget.TransformPoint(moveOffset);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSmoothness * Time.deltaTime);





    }

    void HandleRotation()
    {

        var direction = objectTarget.position - transform.position;
        var rotation = new Quaternion();

        rotation = Quaternion.LookRotation(direction + rotOffset, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSmoothness * Time.deltaTime);


    }



}
