using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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