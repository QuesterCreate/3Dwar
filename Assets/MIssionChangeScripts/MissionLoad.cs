using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  

    public void MissionShoot()
    {
        SceneManager.LoadScene("MissonShoot");

    }

    public void MissionCar()
    {
        SceneManager.LoadScene("MissonCar");
    }

    public void MissionCollectables()
    {
        SceneManager.LoadScene("MissonCollect");
    }



 




}
