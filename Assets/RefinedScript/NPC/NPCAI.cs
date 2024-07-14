using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
   // public GameObject destinationPoint;
    NavMeshAgent theAgent;
    public static bool fleeMode = false;
    public GameObject fleeDest;
    public AudioSource helpMeFx;
    public bool isFleeing = false;
    public Animator anim;
    //[SerializeField] private WayPointsObjectsGenerator generator;

    private Vector3 currentWaypoint;
    [SerializeField] private Vector3 minMaxPoint;
    [SerializeField] private float waypointYPos;
    [SerializeField] private float radius;
   // private bool hasReachedDestination = false;



    public float delayInSeconds = 5f;
    private float elapsedTime = 0.0f;
    




    // Start is called before the first frame update
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentWaypoint = GetWaypoint();
        theAgent.SetDestination(transform.position + currentWaypoint);

        //Initializing the first waypoint

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if( elapsedTime >= delayInSeconds)
        {
           
            MoveTowardsDestination();
        }
        //MoveTowardsDestination();

    }

    private void MoveTowardsDestination()
    {
     
        

        if (fleeMode == false)
        {
            {
              

               //if (!hasReachedDestination && theAgent.remainingDistance <= theAgent.stoppingDistance)
               // {
                   // hasReachedDestination = true;


                    //Now generate a new wayPoint since it has reached current wayPoint

                    currentWaypoint = GetWaypoint();


                    //detect()


                    theAgent.SetDestination(transform.position + currentWaypoint);


                    //hasReachedDestination=false;




              //  }
            }

               delayInSeconds = 5f;
               elapsedTime = 0.0f;
    //Setting the destination to the current random points

    // theAgent.SetDestination(transform.position+currentWaypoint);
}
        else if(fleeMode==true)
        {
            theAgent.SetDestination(fleeDest.transform.position);
            if (isFleeing == false)
            {
                isFleeing = true;
                StartCoroutine(FleeingNPC());
            }

        }
    }



   IEnumerator FleeingNPC()
 {
     helpMeFx.Play();

     yield return new WaitForSeconds(7);
     fleeMode = false;
     isFleeing = false;
     anim.SetTrigger("Walking");
     this.gameObject.GetComponent<NavMeshAgent>().speed = 2.5f;

 }


 public Vector3 GetWaypoint()
 {
     var points = UnityEngine.Random.insideUnitSphere * radius;
     points.x = Mathf.Clamp(points.x, -minMaxPoint.x, minMaxPoint.x);
     points.z = Mathf.Clamp(points.z, -minMaxPoint.z, minMaxPoint.z);
     //clamp
     points.y = waypointYPos;
     return points;
 }

 private Vector3 randomPoint;

 private void OnDrawGizmosSelected()
 {

 Gizmos.color = Color.red;
     Gizmos.DrawWireSphere(transform.position, radius);
     randomPoint = Random.insideUnitSphere * radius;
     randomPoint.x = Mathf.Clamp(randomPoint.x, -minMaxPoint.x, minMaxPoint.x);
     randomPoint.z = Mathf.Clamp(randomPoint.z,-minMaxPoint.z, minMaxPoint.z);
     randomPoint.y = waypointYPos;

     Gizmos.color = Color.green;
     Gizmos.DrawSphere(transform.position + randomPoint, 0.2f);


 }





}















/*  public Transform[] hitPoint;
    private RaycastHit hits;
    private void Detect()
    {
        for (int i = 0; i < hitPoint.Length; i++)
        {
            //Raycast

    if(Physics.RayCast(hitPoint.position, transform.targetPositon.position, out hit,raycastrange){
            if (hits.collider.CompareTag("Building"))
            {
                currentDestination=GetWayPoint()


            }
  }
        }
    }
  */