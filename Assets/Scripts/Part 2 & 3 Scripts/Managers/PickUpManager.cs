using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PickUpManager : MonoBehaviour
{
    //manages the pickups
    public static PickUpManager Instance {  get; private set; }

    public GameObject pickupPrefab1;
    public GameObject pickupPrefab2;
    public GameObject pickupPrefab3;
    public Transform[] spawnPoints;




    public static bool speedUp;
    public static bool invincible;
    public static bool jumpBoost;
    //pickup 3
    public static bool pk3;
    //pickup4
    public static bool pk4;
    public float pickupID;

    public bool spawning;
    


    [Header("Audio clips")]
    public AudioClip speedBuffClip;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        
        // Subscribe to GameManager events
        GameManager.Instance.OnPickup1Activated.AddListener(OnPickup1Activated);
        GameManager.Instance.OnPickup2Activated.AddListener(OnPickup2Activated);
        GameManager.Instance.OnPickup3Activated.AddListener(OnPickup3Activated);
       

        
    }
   
    private void Update()
    {
        
        
       
        
        
    }
    //used to set a delay between spawning pickups
    
    
    
    public Vector3[] hardcodedSpawnPoints = new Vector3[3]
    {
         new Vector3(-3f, 1f, 29.2f),
         new Vector3(0f, 1f, 29.2f),
         new Vector3(3f, 1f, 29.2f)
     };

    //the event for the first pickup is not implemented yet
    private void OnPickup1Activated()
    {
        StartCoroutine(Pickup1());

    }
    //for the second pickup
    private void OnPickup2Activated()
    {
        StartCoroutine(Pickup2());

    }
    //for the third pickup
    private void OnPickup3Activated()
    {
        StartCoroutine(Pickup3());

    }
    //the couroutine for the speed up
    public IEnumerator Pickup2()
    {
        Debug.Log("pickup 2 is activated");
        
        speedUp = true;
        yield return new WaitForSeconds(5);
        //after 5 seconds the pickup effect stops
        speedUp = false;
        
        
    }
    //the couroutine for the invincible powerup
    public IEnumerator Pickup3()
    {
        Debug.Log("pickup 3 is activated");

        invincible = true;
        yield return new WaitForSeconds(5);
        //after 5 seconds the pickup effect stops
        invincible = false;
        

    }
    public IEnumerator Pickup1()
    {
        
        jumpBoost = true;
        yield return new WaitForSeconds(5);
        //after 5 seconds the pickup effect stops
        jumpBoost = false;

    }
    
   
    


}
