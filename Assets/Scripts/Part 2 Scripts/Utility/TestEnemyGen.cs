using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestEnemyGen : MonoBehaviour
{
    //For the player
    GameObject[] player = null;
    float playerZ;

    //for the enemy
    public GameObject Enemy1;
    
    public GameObject Enemy2;
    
    public GameObject Enemy3;
    
    public GameObject Enemy4;
    
   public GameObject[] enemylist = null;
   
    float enemyID;

    //Enemy positions
    float xPosID;
    float xPosE;
    float zPosE;
    float yPosE;

    


    public float enemyCount;
    public float enemyMax;
    public float stage2Enemymax;

    public GameManager gm;
    
    //for the boss
    public GameObject Boss;
     bool BossActive = false;
    float bossXID;


    public GameObject pickup1;
    public GameObject pickup2;
    public GameObject pickup3;
    public GameObject[] pickuplist = null;
    public float pickupMax;
    float pickupID;



    float zMax;
    float zMin;

    public float fixUpdateCount;

    // Start is called before the first frame update
    void Start()
    {
        //boss = GameObject.FindGameObjectsWithTag("Boss");
        
        player = GameObject.FindGameObjectsWithTag("Player");
        Coroutine EnGene = StartCoroutine(EnemySpawn2());
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        stage2Enemymax = enemyMax - 2;
        StartCoroutine(PickupSpawn());

    }
   

    // Update is called once per frame
    void Update()
    {
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");

        pickuplist = GameObject.FindGameObjectsWithTag("Pickup");



        playerZ = player[0].GetComponent<Transform>().position.z;

        StartCoroutine (PickupSpawn());
        zMin = playerZ + 10;
        zMax = playerZ + 30;
            

        //compares the actual amount of enemies to the local enemycount varaible
        
        if(GameManager.Instance.stage==1)
        {
            StartCoroutine(EnemySpawn2());

        }
         
        if(GameManager.Instance.stage==2)
        {
            enemyMax = stage2Enemymax;
            StartCoroutine(EnemySpawn2());
            
            
        }

        
    }
    private void FixedUpdate()
    {
        fixUpdateCount++;
        if (fixUpdateCount == 5000)
        {
            StartCoroutine(SpawnBoss());
            GameManager.Instance.stage = 2;

        }
    }

    IEnumerator PickupSpawn()
    {
        while (pickuplist.Length < pickupMax)
        {
            zPosE = Random.Range(zMin, zMax);
            xPosID = Random.Range(0, 3);
            if (xPosID == 0)
            {
                xPosE = -3f;

            }
            if (xPosID == 1)
            {
                xPosE = 0f;
            }
            else if (xPosID == 2)
            {
                xPosE = 3f;
            }
            yPosE = 1;

            pickupID = Random.Range(0, 3);
            if (pickupID == 0)
            {
                Instantiate(pickup1, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);

            }
            if (pickupID == 1)
            {
                Instantiate(pickup2, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);

            }
            if (pickupID == 2)
            {
                Instantiate(pickup3, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);

            }
            pickuplist = GameObject.FindGameObjectsWithTag("Pickup");


        }

        yield return new WaitForSeconds(0.1f);

    }


    IEnumerator EnemySpawn2()
    {
        while (enemylist.Length < enemyMax)
        {
           

            //These values are not dependent on the type of enemy
            zPosE = Random.Range(zMin, zMax);
            xPosID = Random.Range(0, 3);
            if (xPosID == 0)
            {
                xPosE = -3f;

            }
            if (xPosID == 1)
            {
                xPosE = 0f;
            }
            else if (xPosID == 2)
            {
                xPosE = 3f;
            }
            yPosE = 1;

            enemyID = Random.Range(0, 4);

            if (enemyID == 0)
            {
                //table best y is 1
                Instantiate(Enemy1, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
                //e1Count++;
            }
            if (enemyID == 1)
            {
              //bed  best y is 1
                Instantiate(Enemy2, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
                //e2Count++;

            }
            if (enemyID == 2)
            {
                
                //posti = new Vector3(xPosE, 2, zPosE);
                Instantiate(Enemy3, new Vector3(xPosE,yPosE,zPosE), Quaternion.identity);
                //e3count++;

            }
            if (enemyID == 3)
            {
                Instantiate(Enemy4, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
                //e4Count++;
            }
            yield return new WaitForSeconds(0.1f);
            
            
    
            enemylist = GameObject.FindGameObjectsWithTag("Enemy");
            enemyCount = enemylist.Length;


        }

        yield return new WaitForSeconds(0.1f);

    }
    
    
    
    IEnumerator SpawnBoss()
    {
        while(BossActive==false)
        {
            bossXID = Random.Range(0, 2);
            if(bossXID == 0)
            {
                xPosE = -1;
            }
            if (bossXID == 1)
            {
                xPosE = 1;
            }
            
            zPosE = Random.Range(zMin, zMax);
            yPosE=1.5f;
            Instantiate(Boss, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
            BossActive = true;
            gm.BossSpawn();
            //Debug.Log("boss spawneed");
        }
        

        yield return new WaitForSeconds(5);

    }
    

}
