using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class PlayerInventory : MonoBehaviour
{
    public GameObject missonStatus;
  public int NumberOfDiamonds { get; private set; }
    public UnityEvent<PlayerInventory> OnDiamondCollected;
    public AudioSource diamondCollectedSound;


    private void Awake()
    {
        diamondCollectedSound = GetComponent<AudioSource>();
    }
    public void DiamondCollected()
    {
        NumberOfDiamonds++;
        if (NumberOfDiamonds >= 6)
        {
            missonStatus.SetActive(true);
        }
        diamondCollectedSound.Play();
        OnDiamondCollected.Invoke(this);
       
        HealthManager1.Instance.OnItemCollected();
        
    }

}
