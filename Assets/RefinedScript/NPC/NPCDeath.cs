/*

using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCDeath : MonoBehaviour
{
    public int npcHealth = 20;
    public bool npcDead = false;
    public GameObject npcObject;
    public GameObject interactionTrigger;
    public GameObject helpMe;

    public void HurtNPC(int shotDamage)
    {
        npcHealth -= shotDamage;
    }

    void Update()
    {
        this.gameObject.transform.position = npcObject.transform.position;
        if (npcHealth <= 0 && npcDead == false)
        {
            npcDead = true;
            GameManager.Instance.AddKill(); // Report the kill to the GameManager
            HealthManager.Instance.OnEnemyKilled();
            StartCoroutine(EndNPC());
        }
    }

    IEnumerator EndNPC()
    {
        npcObject.GetComponent<NPCAI>().enabled = false;
        npcObject.GetComponent<NavMeshAgent>().enabled = false;
        npcObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        interactionTrigger.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        npcObject.GetComponent<Animator>().Play("Dying");
        this.helpMe.SetActive(false);
        yield return new WaitForSeconds(3);
        npcObject.GetComponent<Animator>().enabled = false;
        npcObject.SetActive(false);
    }
}
*/







using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCDeath : MonoBehaviour
{
    public int npcHealth = 20;
    public bool npcDead = false;
    public GameObject npcObject;
    public GameObject interactionTrigger;
    public GameObject helpMe;

    public void HurtNPC(int shotDamage)
    {
        npcHealth -= shotDamage;
    }

    void Update()
    {
        this.gameObject.transform.position = npcObject.transform.position;
        if (npcHealth <= 0 && npcDead == false)
        {
            npcDead = true;
            GameManager.Instance.AddKill(); // Report the kill to the GameManager
            HealthManager.Instance.OnEnemyKilled();
            StartCoroutine(EndNPC());
        }
    }

    IEnumerator EndNPC()
    {
        npcObject.GetComponent<NPCAI>().enabled = false;
        npcObject.GetComponent<NavMeshAgent>().enabled = false;
        npcObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        interactionTrigger.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        npcObject.GetComponent<Animator>().Play("Dying");
        this.helpMe.SetActive(false);
        yield return new WaitForSeconds(3);
        npcObject.GetComponent<Animator>().enabled = false;
        npcObject.SetActive(false);
    }
}
