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

    public GameObject[] platformprefabs1;
    public GameObject[] platformprefabs2;

    public GameObject bossPlatformPrefab1;
    public GameObject bossPlatformPrefab2;

    public GameObject endPlatformPrefab1;
    public GameObject endPlatformPrefab2;
    
    
    

    public int bossSpawnDelay = 15;
    


    private string currentLevelName = "Level1";

    // Start is called before the first frame update
    void Start()
    {
        
        GameManager.Instance.OnBoss2Spawned.AddListener(StartBossSpawnDelay);
        GameManager.Instance.OnBoss1Spawned.AddListener(StartBossSpawnDelay);
        
        //Coroutine EnGene =StartCoroutine(SpawnEnemiesRoutine());

        //LevelManager.Instance.OnNextLevelLoad.AddListener(NextlevelEnemiesSpawn);



        

    }
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
    public void SpawnEndPlatform()
    {
        if (LevelManager.Instance.currentLevelName == "Level1")
        {
            Instantiate(endPlatformPrefab1, new Vector3(0, 0, 39), Quaternion.identity);

        }
        if (LevelManager.Instance.currentLevelName == "Level2")
        {
            Instantiate(endPlatformPrefab2, new Vector3(0, 0, 39), Quaternion.identity);

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
   
    

    private void StartBossSpawnDelay()
    {
        Debug.Log("in start spawndelay metrhod");
        
        
        
        StartCoroutine(BossSpawnDelay());
        
        
    }
    public IEnumerator BossSpawnDelay()
    {
        Debug.Log("in spawn delay coroutine");
        yield return new WaitForSeconds(bossSpawnDelay);
        
        
        if (currentLevelName == "Level1")
        {
           Debug.Log("abou to enter boss spawn method");
            //SpawnBoss1();
            SpawnBoss2();
        }
        if (currentLevelName == "Level2")
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

    private void SpawnBoss1()
    {
        Vector3 spawningSpot = hardcodedSpawnPoints[Random.Range(0, hardcodedSpawnPoints.Length)];
        Debug.Log("in boss spawn method");
        
        
        
        Quaternion boss = Quaternion.Euler(0, 90, 0);
        Instantiate(Boss1, spawningSpot, boss);
        StartCoroutine(EndBossAfterDelay());

    }
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
        if (LevelManager.Instance.currentLevelName=="GameOver")
        {
            //GameOverStopSpawning();
        }
        
        
        
    }
   
   
    
}
