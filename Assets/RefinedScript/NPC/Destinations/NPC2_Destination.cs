using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2_Destination : MonoBehaviour
{
    public int trigNum;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC2")
        {


            if (trigNum == 4)
            {

                trigNum = 0;
            }


            if (trigNum == 3)
            {

                this.gameObject.transform.position = new Vector3(-103, 1, -25);
                trigNum = 4;
            }
            if (trigNum == 2)
            {

                this.gameObject.transform.position = new Vector3(89, 1, -10);
                trigNum = 3;
            }

            if (trigNum == 1)
            {

                this.gameObject.transform.position = new Vector3(87, 1, -15);
                trigNum = 2;
            }

            if (trigNum == 0)
            {

                this.gameObject.transform.position = new Vector3(89, 1, -5);
                trigNum = 1;
            }

        }
    }
}
