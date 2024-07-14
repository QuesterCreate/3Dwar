using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC5_Destination : MonoBehaviour
{
    public int trigNum;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC5")
        {


            if (trigNum == 4)
            {

                trigNum = 0;
            }


            if (trigNum == 3)
            {

                this.gameObject.transform.position = new Vector3(30, 1,15);
                trigNum = 4;
            }
            if (trigNum == 2)
            {

                this.gameObject.transform.position = new Vector3(25, 1, 28);
                trigNum = 3;
            }

            if (trigNum == 1)
            {

                this.gameObject.transform.position = new Vector3(20, 1, 35);
                trigNum = 2;
            }

            if (trigNum == 0)
            {

                // this.gameObject.transform.position = new Vector3(10, 1, 31);
                this.gameObject.transform.position = new Vector3(-96, 1, -26); ;
               
                trigNum = 1;
            }

        }
    }
}
