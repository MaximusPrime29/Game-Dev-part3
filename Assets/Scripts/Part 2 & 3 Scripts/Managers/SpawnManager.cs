using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager Instance;

    
    
    
    public GameObject Boss1;
    public GameObject Boss2;

    //the platforms for level 1 and 2
    public GameObject[] platformprefabs1;
    public GameObject[] platformprefabs2;

    //the platforms that spawn when the boss is active
    public GameObject bossPlatformPrefab1;
    public GameObject bossPlatformPrefab2;

    //the platfrom at the end of each level
    public GameObject endPlatformPrefab1;
    public GameObject endPlatformPrefab2;
    
    
    

    public int bossSpawnDelay = 15;
    


    

    // Start is called before the first frame update
    void Start()
    {
        
        GameManager.Instance.OnBoss2Spawned.AddListener(StartBossSpawnDelay);
        GameManager.Instance.OnBoss1Spawned.AddListener(StartBossSpawnDelay);
        
        



        

    }
    //spawns the boss platform
    public void SpawnBossPlatform()
    { 
        if (LevelManager.Instance.currentLevelName=="Level1")
        {
            Instantiate(bossPlatformPrefab1, new Vector3(0, 0, 39), Quaternion.identity);

        }
        if (LevelManager.Instance.currentLevelName == "Level2")
        {
            Instantiate(bossPlatformPrefab2, new Vector3(0, 0, 39), Quaternion.identity);

        }


    }
    //spawns the end platform
    public void SpawnEndPlatform()
    {
         
        if (LevelManager.Instance.currentLevelName == "Level1")
        {
            Instantiate(endPlatformPrefab1, new Vector3(0, 0, 39.2f), Quaternion.identity);

        }
        if (LevelManager.Instance.currentLevelName == "Level2")
        {
            Instantiate(endPlatformPrefab2, new Vector3(0, 0, 39.2f), Quaternion.identity);

        }

    }

    public void SpawnRandomPlatform()
    {
        if (LevelManager.Instance.currentLevelName=="Level1")
        {
            int randomIndex = Random.Range(0, platformprefabs1.Length);
            Debug.Log(randomIndex);
            GameObject selectedPlatfrom = platformprefabs1[randomIndex];
            Instantiate(selectedPlatfrom, new Vector3(0, 0, 39), Quaternion.identity);

        }
        if (LevelManager.Instance.currentLevelName=="Level2")
        {
            int randomIndex = Random.Range(0, platformprefabs2.Length);
            GameObject selectedPlatfrom = platformprefabs2[randomIndex];
            Instantiate(selectedPlatfrom, new Vector3(0, 0, 39), Quaternion.identity);

        }

    }
   
    
    //a delay when spawning the boss so that there is time for the player to move past the obstacles
    private void StartBossSpawnDelay()
    {
        Debug.Log("in start spawndelay metrhod");
        
        
        
        StartCoroutine(BossSpawnDelay());
        
        
    }
    public IEnumerator BossSpawnDelay()
    {
        Debug.Log("in spawn delay coroutine");
        yield return new WaitForSeconds(bossSpawnDelay);
        
        
        if (LevelManager.Instance.currentLevelName == "Level1")
        {
           Debug.Log("abou to enter boss spawn method");
            SpawnBoss1();
            //SpawnBoss2();
        }
        if (LevelManager.Instance.currentLevelName == "Level2")
        {
             SpawnBoss2();
        }
        

        
       
    }
   


    
    
    public Vector3[] hardcodedSpawnPoints = new Vector3[3]
    {
         new Vector3(-3f, 0.54f, 29f),
         new Vector3(0f, 0.54f, 29f),
         new Vector3(3f, 0.54f, 29f)
    };

    //spawns the first boss
    private void SpawnBoss1()
    {
        Vector3 spawningSpot = hardcodedSpawnPoints[Random.Range(0, hardcodedSpawnPoints.Length)];
        Debug.Log("in boss spawn method");
        
        
        
        Quaternion boss = Quaternion.Euler(0, 90, 0);
        Instantiate(Boss1, spawningSpot, boss);
        StartCoroutine(EndBossAfterDelay());

    }
    //spawns the second boss
    private void SpawnBoss2()
    {
        Vector3 spawningSpot = new Vector3(0f, 2f, 29.2f);
        

        Quaternion boss = Quaternion.Euler(0, 90, 0);
        Instantiate(Boss2, spawningSpot, boss);
        StartCoroutine(EndBossAfterDelay());

    }
    private IEnumerator EndBossAfterDelay()
    {
        Debug.Log("in boss aftyer delay");
        yield return new WaitForSeconds(bossSpawnDelay);
        DestroyBoss();
    }
    //destroys the boss after a given time
    private void DestroyBoss()
    {
        Debug.Log("In boss destroy method");
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            Destroy(boss);
            GameManager.Instance.DefeatBoss();
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        
    }
   
   
    
}
