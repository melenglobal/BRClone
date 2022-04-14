using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandlerEvent : EventArgs
{
    public GameObject PickupObject { get; set; }

}

public class DropHandlerEvent : EventArgs 
{
    public GameObject DroppedObject { get; set; }

}

