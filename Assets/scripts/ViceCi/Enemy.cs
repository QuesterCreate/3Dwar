using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    // [Header("Enemy Health and Damage")]
    [Header("Enemy Things")]
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
    // [Header("Enemy Shooting Var")]
    // [Header("Enemy Animation and Spark Effect")]
    // [Header("Enemy mood / situation")]

    public float visionRadius;
    public float shootingRadius;
    public bool playerInvisionRadius;
    public bool playerInshootingRadius;


    private void Awake()
    {

        playerBody = GameObject.Find("Player").transform;
        enemyAgent = GetComponent<NavMeshAgent>();
        //   playerBody = PlayerManager.instance.player.transform;

    }



    private void Update()
    {

        playerInvisionRadius = Physics.CheckSphere(transform.position, visionRadius, PlayerLayer);
        playerInshootingRadius = Physics.CheckSphere(transform.position, shootingRadius, PlayerLayer);

        if (!playerInvisionRadius && !playerInshootingRadius) Guard();
        if(playerInvisionRadius &&!playerInshootingRadius) PursuePlayer();


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

    private void PursuePlayer(){
        if (enemyAgent != null && playerBody != null)
        {
            enemyAgent.SetDestination(playerBody.position);
            
      visionRadius=16f;
        shootingRadius=8f;
        }
    
        // Debug to ensure it’s being called
        Debug.Log("Pursuing Player: " + playerBody.position);

//Animations

    }





    void OnDrawGizmosSelected()
    {

       Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootingRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, walkingPointRadius);

    }

}
