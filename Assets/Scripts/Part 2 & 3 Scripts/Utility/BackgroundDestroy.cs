using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDestroy : MonoBehaviour
{
    //if an object is behind the player by a certain distance they are destroyed
    
    
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (transform.position.z<=-30f)
        {
            Destroy(gameObject);

        }
        //if that distance is greater then 30 the object is destroyed
        
       
            

    }
}
