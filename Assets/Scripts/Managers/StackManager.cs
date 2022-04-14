using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class StackManager : MonoBehaviour
{
    #region : Values

    public GameObject player;

    public Transform peekPosition;

    public Transform peekPositionRight;

    private GameObject prevObj;

    public List<GameObject> stackList;

    public List<GameObject> bridgeStairList; 

    private PathType stackPathSystem = PathType.CatmullRom;

    private Vector3[] pathVal = new Vector3[2];

    Vector3 stackPos;

    #endregion

    void Start()
    {
        AddEvents();
        stackPos = this.transform.localPosition;

    }

    private void OnDestroy()
    {
        RemoveEvents();
    }

    #region : Stack object
    private void StackedObject(object sender, PickUpHandlerEvent e)
    {
        stackList.Add(e.PickupObject);

        prevObj = stackList[stackList.Count - 1];

        prevObj.transform.SetParent(this.transform);

        prevObj.transform.GetComponent<BoxCollider>().enabled = false;

        if (stackList.Count % 2 ==0)
        {
            pathVal[0] = peekPositionRight.localPosition;
        }
        else
        {
            pathVal[0] = peekPosition.localPosition;
        }

        pathVal[1] = stackPos;

        prevObj.transform.DOLocalPath(pathVal, .2f, stackPathSystem).OnComplete(() => {
            prevObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
            prevObj.transform.GetComponent<TrailRenderer>().enabled = false;
            stackPos.y = prevObj.transform.localPosition.y + 0.2f;
        });

        peekPosition.transform.localPosition += new Vector3(0, 0.2f, 0);

    }

    private void BridgeBuilder()
    {

    }
    #endregion

    private void AddEvents()
    {
        PlayerManager.instance.OnPickupEvent += StackedObject;
    }


    public void RemoveEvents()
    {
        PlayerManager.instance.OnPickupEvent -= StackedObject;
    }

}
