using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 Everything Ok now
public class PlayerManager : MonoBehaviour
{
    
#region Singletion
public static PlayerManager instance;

void Awake(){

instance=this;

}

#endregion
public GameObject player;

}