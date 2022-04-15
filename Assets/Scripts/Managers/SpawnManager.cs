using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public List<Transform> Collectables;
    public List<GameObject> Platform;

    void Start()
    {

        Collectables = new List<Transform>();

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        foreach (GameObject platform in platforms)
        {
            Platform.Add(platform);
            
        }

        for (int i = 0; i < Platform.Count; i++)
        {
            PlatformController platformController = Platform[i].transform.GetComponent<PlatformController>();

            if ( platformController.platformType == PlatformController.PlatformType.CurrentPlatform)
            {
                for (int j = 0; j < Platform[i].transform.childCount; j++)
                {
                    Collectables.Add(Platform[i].transform.GetChild(j));
                }
            }
        }
        
       Debug.Log(Collectables.Count);

    }

    void Update()
    {
        
    }
}
