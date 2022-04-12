using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class StackManager : MonoBehaviour
{
    public GameObject player;

    public Transform peekPosition;

    private GameObject prevObj;

    public List<GameObject> stackList;

    private PathType stackPathSystem = PathType.CatmullRom;

    private Vector3[] pathVal = new Vector3[2];

    Vector3 stackPos;

    void Start()
    {
        AddEvents();
        stackPos = this.transform.position;

    }

    private void OnDestroy()
    {
        RemoveEvents();
    }

    
    private void PickUpObjects(object sender, PickUpHandlerEvent e)
    {
        stackList.Add(e.PickupObject);

        prevObj = stackList[stackList.Count - 1];

        prevObj.transform.SetParent(this.transform);

        pathVal[0] = peekPosition.localPosition;

        pathVal[1] = stackPos;

        prevObj.transform.DOLocalPath(pathVal, .3f, stackPathSystem).OnComplete(() => stackPos.y = prevObj.transform.localPosition.y + 0.2f);

        peekPosition.transform.localPosition += new Vector3(0, 0.2f, 0);


    }

    private void AddEvents()
    {
        PlayerManager.instance.OnPickupEvent += PickUpObjects;
    }


    public void RemoveEvents()
    {
        PlayerManager.instance.OnPickupEvent -= PickUpObjects;
    }

    private void AddToStack(PickUpHandlerEvent e)
    {

    }
}
