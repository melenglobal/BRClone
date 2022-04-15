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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            var pickupObjectEventData = new PickUpHandlerEvent
            {
                PickupObject = other.gameObject,
            };

            OnPickupEvent?.Invoke(this, pickupObjectEventData);
        }

        if (other.gameObject.CompareTag("StairCollider"))
        {
            var droppedObjectEventData = new DropHandlerEvent
            {
                DroppedObject = other.gameObject,
            };
        }
    }
}
