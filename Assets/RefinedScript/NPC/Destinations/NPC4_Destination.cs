using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC4_Destination : MonoBehaviour
{
    public int trigNum;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC4")
        {


            if (trigNum == 4)
            {

                trigNum = 0;
            }


            if (trigNum == 3)
            {

                this.gameObject.transform.position = new Vector3(30, 1, -32);
                trigNum = 4;
            }
            if (trigNum == 2)
            {

                this.gameObject.transform.position = new Vector3(-30, 1, -35);
                trigNum = 3;
            }

            if (trigNum == 1)
            {

                this.gameObject.transform.position = new Vector3(-12, 1, -32);
                trigNum = 2;
            }

            if (trigNum == 0)
            {

                this.gameObject.transform.position = new Vector3(-33, 1, -33);
                trigNum = 1;
            }

        }
    }
}