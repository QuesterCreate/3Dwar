using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public GameObject ourPistol;
    public GameObject currentPistol;
    // public AudioSource gunPickup; //later for the audio


    private void OnTriggerEnter(Collider other)
    {
        ourPistol.SetActive(true);
        currentPistol.SetActive(false);
        this.gameObject.SetActive(false);
    }










}
