using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPistol : MonoBehaviour
{

    private Animator anim;
    
    public bool isAiming = false;
    public AudioSource pistolShot;
    public GameObject aimingObject;
    public Transform gunTransform;  //Reference to the gun's transform;


    public static float distanceFromTarget;
    public float toTarget;
    public int shotDamage;
   

    

    private void Start()
    {
         anim = GetComponent<Animator>();
       
        
    }




    private void Update()
    {

        RaycastHit Hit;


        if (Input.GetMouseButtonDown(1))
        {

            isAiming = true;
            Aim();
            aimingObject.SetActive(true);
        }
        else
        {
            isAiming = false;
            aimingObject.SetActive(false);
        }



       if( Input.GetMouseButtonDown(0))
        {
           
            if(Physics.Raycast(gunTransform.position, gunTransform.TransformDirection(Vector3.forward), out Hit))
            {
                

                
                toTarget = Hit.distance;
                distanceFromTarget = toTarget;
                shotDamage = 20;
                Hit.transform.SendMessage("HurtNPC", shotDamage, SendMessageOptions.DontRequireReceiver);
            }
            Attack();
            pistolShot.Play();
        }
        

    }








    private void Attack()
    {
        
        anim.SetTrigger("Attack");
        
    }

    private void Aim()
    {

      
        
        anim.SetTrigger("Aim");
       


    }






    void OnDrawGizmos()
    {
        RaycastHit hit;

        // Perform raycast in editor only to draw Gizmos
        if (Physics.Raycast(gunTransform.position, gunTransform.forward, out hit))
        {
            // Draw a line from the gun's position to the hit point
            Gizmos.color = Color.red;
            Gizmos.DrawLine(gunTransform.position, hit.point);

            // Draw a sphere at the hit point
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(hit.point, 0.2f);
        }
    }
}




