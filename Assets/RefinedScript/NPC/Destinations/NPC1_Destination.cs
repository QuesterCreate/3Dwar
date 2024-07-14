using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1_Destination : MonoBehaviour
{
    public int trigNum;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            
          
            if (trigNum == 4)
            {

                trigNum = 0;
            }


            if (trigNum == 3)
            {

                this.gameObject.transform.position = new Vector3(-103, 1, 5);
                trigNum = 4;
            }
            if (trigNum == 2)
            {

                this.gameObject.transform.position = new Vector3(-98, 1, 20);
                trigNum = 3;
            }

            if (trigNum == 1)
            {

                this.gameObject.transform.position = new Vector3(-98, 1, 28);
                trigNum = 2;
            }

            if (trigNum == 0)
            {

                this.gameObject.transform.position = new Vector3(-97, 1, -3);
                trigNum = 1;
            }

        }
    }
}
