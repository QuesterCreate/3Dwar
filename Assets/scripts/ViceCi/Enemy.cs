using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    // [Header("Enemy Health and Damage")]
    [Header("Enemy Things")]
    public Transform LookPoint;
    public Camera ShootingRaycastArea;
    public NavMeshAgent enemyAgent;
    public Transform playerBody;
    // Transform playerBody;

    public LayerMask PlayerLayer;

    // [Header("Enemy Guarding Var")]
    public GameObject[] walkPoints;
    int currentEnemyPosition = 0;
    public float enemySpeed;
    public float walkingPointRadius = 2;

    // [Header("Sounds and UI")]

    [Header("Enemy Shooting Var")]
    public float timebetweenShoot;
    bool previouslyShoot;




public float damage = 10f;






    // [Header("Enemy Animation and Spark Effect")]
    // [Header("Enemy mood / situation")]

    public float visionRadius;
    public float shootingRadius;
    public bool playerInvisionRadius;
    public bool playerInshootingRadius;


    private void Awake()
    {

        playerBody = GameObject.Find("ThirdPersonPlayer").transform;
        enemyAgent = GetComponent<NavMeshAgent>();
        //   playerBody = PlayerManager.instance.player.transform;

    }



    private void Update()
    {

        playerInvisionRadius = Physics.CheckSphere(transform.position, visionRadius, PlayerLayer);
        playerInshootingRadius = Physics.CheckSphere(transform.position, shootingRadius, PlayerLayer);

        if (!playerInvisionRadius && !playerInshootingRadius) Guard();
        if (playerInvisionRadius && !playerInshootingRadius) PursuePlayer();
        if (playerInvisionRadius && playerInshootingRadius) ShootPlayer();


    }
    private void Guard()
    {
        if (Vector3.Distance(walkPoints[currentEnemyPosition].transform.position, transform.position) < walkingPointRadius)
        {
            currentEnemyPosition = Random.Range(0, walkPoints.Length);
            if (currentEnemyPosition >= walkPoints.Length)
            {
                currentEnemyPosition = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentEnemyPosition].transform.position, Time.deltaTime * enemySpeed);

        //changing enemy facing
        transform.LookAt(walkPoints[currentEnemyPosition].transform.position);

    }

    private void PursuePlayer()
    {
        if (enemyAgent != null && playerBody != null)
        {
            enemyAgent.SetDestination(playerBody.position);

            visionRadius = 16f;
            shootingRadius = 8f;
        }

        // Debug to ensure it’s being called
        Debug.Log("Pursuing Player: " + playerBody.position);

        //Animations

    }








    private void ShootPlayer()
    {
        enemyAgent.SetDestination(transform.position);
        transform.LookAt(LookPoint);
        if (previouslyShoot)
        {
            RaycastHit hit;
            if (Physics.Raycast(ShootingRaycastArea.transform.position, ShootingRaycastArea.transform.forward, out hit, shootingRadius))
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

    void OnDrawGizmosSelected()
{

         RaycastHit hit;
        
        
            Gizmos.color = Color.red;

           if (Physics.Raycast(ShootingRaycastArea.transform.position, ShootingRaycastArea.transform.forward, out hit, shootingRadius))
            {
                // Draw the ray from the camera to the hit point
                Gizmos.DrawLine(ShootingRaycastArea.transform.position, hit.point);

                // Draw a small sphere at the hit point
                Gizmos.DrawSphere(hit.point, 0.2f);
            }
            else
            {
                // Draw the ray to the max range
                Gizmos.DrawLine(ShootingRaycastArea.transform.position, ShootingRaycastArea.transform.position + ShootingRaycastArea.transform.forward *shootingRadius);
            }
        
  

        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(transform.position, visionRadius);
        // Gizmos.color = Color.blue;
        // Gizmos.DrawWireSphere(transform.position, shootingRadius);
        // Gizmos.color = Color.green;
        // Gizmos.DrawWireSphere(transform.position, walkingPointRadius);

    }
}
