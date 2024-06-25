using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleEnterExit : MonoBehaviour
{
    public string playerTag;
    public GameObject playerObject;

    public Transform targetPosition;
    public bool isPlayerInside ;
    public bool hasPlayerInArea;

    private CarController my_carEngine = null;

    // [SerializeField] private GameObject playerCamera;
    // [SerializeField] private GameObject carCamera;
    private void Start()
    {


        GameObject car = GameObject.Find("Free Racing Car");
        if (car != null)
        {

            my_carEngine = car.GetComponent<CarController>();
        }

    }

    private void Update()
    {
        if (!isPlayerInside)
        {
            my_carEngine.enabled = false;


        }
        else if (isPlayerInside)
        {
            my_carEngine.enabled = true;

        }


        if (!hasPlayerInArea)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Return) && isPlayerInside)
        {
            ExitVehicle();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !isPlayerInside)
        {
            EnterVehicle();
        }

    }
    private void EnterVehicle()
    {

        playerObject.SetActive(false);
        isPlayerInside = true;


        // if (isPlayerInside)
        // {
            
        // }

    }

    private void ExitVehicle()
    {
        playerObject.transform.position = targetPosition.position;
        playerObject.SetActive(true);
        isPlayerInside = false;
        // playerCamera.SetActive(true);
        // carCamera.SetActive(false);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerObject = other.transform.parent.gameObject; //player found
            hasPlayerInArea = true;


        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (isPlayerInside)
        {
            return;
        }
        hasPlayerInArea = false;

    }


}
