using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerManager: MonoBehaviour
    {

    public event EventHandler <PickUpHandlerEvent> OnPickupEvent;


    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            var pickupObjectEventData = new PickUpHandlerEvent
            {
                PickupObject = other.gameObject,
                
            };
 
            OnPickupEvent?.Invoke(this, pickupObjectEventData);
        }
  
    }
}
