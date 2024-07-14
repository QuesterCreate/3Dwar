/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCAlerted : MonoBehaviour
{
    public  Animator anim;
    public string npcTag = "NPC";

    private void Start()
    {
        //anim = GetComponent<Animator>();
        FindAnimatorByTag();
    }

    private void FindAnimatorByTag()
    {
        GameObject npc = GameObject.FindWithTag(npcTag);
        if (npc != null)
        {
            anim = npc.GetComponent<Animator>();
        }
        else if (npc == null)
        {
            Debug.Log("No NPC game object found with tag" + npcTag);
        }
    }


    private void OnTriggerEnter(Collider Npc)
    {
        if (Npc.tag == "NPC")
        {
            NPCAI.fleeMode = true;
            Running();
            Npc.GetComponent<NavMeshAgent>().speed = 7;
            
            
           
        }
    }


    void Running()
    {

        
        if (anim != null)
        {
            anim.SetTrigger("Running");
        }
        else
        {
            Debug.LogWarning("No Animator found to trigger Running.");
        }
    }
}
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCAlerted : MonoBehaviour
{
    public Animator anim;
    public string npcTag = "NPC";

    private void Start()
    {
        anim = GetComponent<Animator>();
       // FindAnimatorByTag();
    }

  /*  private void FindAnimatorByTag()
    {
        GameObject npc = GameObject.FindWithTag(npcTag);
        if (npc != null)
        {
            anim = npc.GetComponent<Animator>();
        }
        else if (npc == null)
        {
            Debug.Log("No NPC game object found with tag" + npcTag);
        }
    }
  */

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {

            this.gameObject.GetComponent<NavMeshAgent>().speed = 7;
            NPCAI.fleeMode = true;
            Running();
            



        }
    }


    void Running()
    {


        if (anim != null)
        {
            anim.SetTrigger("Running");
        }
        else
        {
            Debug.LogWarning("No Animator found to trigger Running.");
        }
    }
}