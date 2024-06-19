using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SectionTrigger : MonoBehaviour
{
    //used to spawn new platforms
    
    //public GameObject roadSection;
    public int secNum;

    
    

    public bool bossPhase = false;
    public bool endPhase = false;
    

    private void OnTriggerEnter(Collider other)
    {
        //chooese a random section to generate
        secNum = Random.Range(0, 3);
        if (other.gameObject.CompareTag("Trigger"))
        {

            
            //where the platform is spawned
            if (bossPhase==false & endPhase==false)
            {
                SpawnManager.Instance.SpawnRandomPlatform();
                

            }
            if (bossPhase ==true)
            {
                SpawnManager.Instance.SpawnBossPlatform();

            }
            //if the boss is beaten we will spawn the end platform
            if (endPhase==true)
            {
                SpawnManager.Instance.SpawnEndPlatform();
                Debug.Log("should spawn endplatform");
                
                enabled = false;
                


            }
                
        }

        

    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnBossBeaten.AddListener(LoadEndPlatform);
        GameManager.Instance.OnBoss1Spawned.AddListener(LoadBossPlatForm);
        GameManager.Instance.OnBoss2Spawned.AddListener(LoadBossPlatForm);
             

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadEndPlatform()
    {
        bossPhase = false;
        endPhase=true;

    }
    public void LoadBossPlatForm()
    {
        bossPhase=true;

    }
}
