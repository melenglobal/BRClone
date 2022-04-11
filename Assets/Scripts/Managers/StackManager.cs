using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StackManager : MonoBehaviour
{
    private GameObject prevObj;

    Vector3 pos;
    void Start()
    {
        AddEvents();
    }

    private void OnDestroy()
    {
        RemoveEvents();
    }

    
    private void PickUpObjects(object sender, PickUpHandlerEvent e)
    {
        
        e.PickupObject.transform.SetParent(this.transform);
        e.PickupObject.transform.localPosition = Vector3.zero;

        pos = e.PickupObject.transform.localPosition;

        if (prevObj!=null)
        {
            pos.x = 0;
            pos.y += prevObj.transform.position.y + .5f;
            pos.z = 0;
            e.PickupObject.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            e.PickupObject.transform.localPosition = pos;

        }
        prevObj = e.PickupObject;
        

    }

    private void AddEvents()
    {
        PlayerManager.instance.OnPickupEvent += PickUpObjects;
    }

    

    public void RemoveEvents()
    {
        PlayerManager.instance.OnPickupEvent -= PickUpObjects;
    }
}
