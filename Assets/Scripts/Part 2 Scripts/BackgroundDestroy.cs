using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDestroy : MonoBehaviour
{
    GameObject[] player = null;
    float playerZ;
    float objectZ;
    float zDistance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        objectZ = GetComponent<Transform>().position.z;
        playerZ = player[0].GetComponent<Transform>().position.z;
        zDistance = objectZ + playerZ;
        if (zDistance<- 30)
        {
            Destroy(gameObject);

        }


        
            

    }
}
