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
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Collectable"))
        {
            var pickupObjectEventData = new PickUpHandlerEvent
            {
                PickupObject = hit.gameObject,
            };

            OnPickupEvent?.Invoke(this, pickupObjectEventData);
        }

        if (hit.gameObject.CompareTag("StairCollider"))
        {
            var droppedObjectEventData = new DropHandlerEvent
            {
                DroppedObject = hit.gameObject,
            };
        }
    }
}
