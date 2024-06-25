using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour



{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject carCamera;
    private VehicleEnterExit enterExit=null;
    // // Start is called before the first frame update
    void Start()
    {
        GameObject car = GameObject.Find("EnterExit");
        if (car != null)
        {
            enterExit = car.GetComponent<VehicleEnterExit>();
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (!enterExit.isPlayerInside)
        {
            playerCamera.SetActive(true);
            carCamera.SetActive(false);
        }
        if (enterExit.isPlayerInside)
        {
            playerCamera.SetActive(false);
            carCamera.SetActive(true);
        }
    }
}
