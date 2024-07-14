using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

   
    public Camera ShootingRaycastArea;
     public float timebetweenShoot;
    bool previouslyShoot;




    // public Cinemachine.CinemachineFreeLook tpsCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Shoot();
            ShootPlayer();
        }
    }



private void ShootPlayer()
    {
       
       
        if (previouslyShoot)
        {
            RaycastHit hit;
            if (Physics.Raycast(ShootingRaycastArea.transform.position, ShootingRaycastArea.transform.forward, out hit, range))
            {

                Debug.Log("Shooting" + hit.transform.name);
       Target target = hit.transform.GetComponent<Target>();  //hit can be anything so we specified it to type target
            if (target != null)
            {

                target.TakeDamage(damage);


            }


            }

            previouslyShoot = true;
            Invoke(nameof(ActiveShooting), timebetweenShoot);



        }


    }


    private void ActiveShooting()
    {

        previouslyShoot = false;

    }

















    // void Shoot()
    // {
    //     RaycastHit hit;
    //     if (Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit, range))
    //     {
    //         Debug.Log(hit.transform.name);
    //         Target target = hit.transform.GetComponent<Target>();  //hit can be anything so we specified it to type target
    //         if (target != null)
    //         {

    //             target.TakeDamage(damage);


    //         }


    //     }

    // }

    void OnDrawGizmos()
    {


         RaycastHit hit;
        // Only draw if the ray exists
        if (ShootingRaycastArea != null)
        {
            Gizmos.color = Color.red;

            if (Physics.Raycast(ShootingRaycastArea.transform.position, ShootingRaycastArea.transform.forward, out hit, range))
            {
                // Draw the ray from the camera to the hit point
                Gizmos.DrawLine(ShootingRaycastArea.transform.position, hit.point);

                // Draw a small sphere at the hit point
                Gizmos.DrawSphere(hit.point, 0.2f);
            }
            else
            {
                // Draw the ray to the max range
                Gizmos.DrawLine(ShootingRaycastArea.transform.position, ShootingRaycastArea.transform.position + ShootingRaycastArea.transform.forward * range);
            }
        }
    }





}
