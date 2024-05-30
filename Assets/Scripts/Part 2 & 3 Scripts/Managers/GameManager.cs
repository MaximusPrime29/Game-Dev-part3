using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    
    //the unity events
    public UnityEvent OnObstaclePassed;
    public UnityEvent OnPickup1Activated;
    public UnityEvent OnPickup2Activated;
    public UnityEvent OnPickup3Activated;
    public UnityEvent OnBossSpawned;
    public UnityEvent OnBossBeaten;
    




    private int obstaclesPassedScore = 0;
    private int levelsBeaten = 0;

    public bool playerLive;
    public bool bossDeath;
    
   

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        //ensures there id only one gamemanger class at a time
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this) 
        {
            //Debug.Log("hello");
            Destroy(gameObject);
        }
        
        //stage = 1;
    }
    //the method for increasing score
    public void IncrementObstaclesPassedScore()
    {
        obstaclesPassedScore++;
        //Debug.Log("Obstacles Passed: " + obstaclesPassedScore);

        //calls the onobstacle passed event and invokes all registered callbacks, such as the Uimanager listening to this event and then updating the score
        OnObstaclePassed.Invoke();
    }
    


    //shows the score

    

    //shows the stage
    //[Serialize
    public GameObject[] enemylist = null;
    void Start()
    {
        //if the events dont exist then we declare them as new events
        if (OnObstaclePassed == null) OnObstaclePassed = new UnityEvent();
        if (OnPickup1Activated == null) OnPickup1Activated = new UnityEvent();
        if(OnPickup2Activated == null) OnPickup2Activated = new UnityEvent();
        if(OnPickup3Activated == null) OnPickup3Activated = new UnityEvent();
        if (OnBossSpawned == null) OnBossSpawned = new UnityEvent();
        if(OnBossBeaten == null) OnBossBeaten = new UnityEvent();
        

        


        //UIManager.Instance.Initialize();
        //LevelManager.Instance.Initialize();
        //InputManager.Instance.Initialize();

    }
    //used to get what the score is from the gamemanager
    public int GetObstaclesPassedScore()
    {
        return obstaclesPassedScore;
    }
    //used to get what the level beaten is from the gamemanager
    public int GetLevelsBeaten()
    {
        return levelsBeaten;

    }
    //invokes the first pickup method
    public void ActivatePickup1()
    {
        //calls the event and invokes all registered callbacks
        OnPickup1Activated.Invoke();

    }
    public void ActivatePickup2()
    {
        //calls the event and invokes all registered callbacks
        OnPickup2Activated.Invoke();

    }
    public void ActivatePickup3()
    {
        //calls the event and invokes all registered callbacks
        OnPickup3Activated.Invoke();

    }
    public void SpawnBoss()
    {
        //calls the event and invokes all registered callbacks
        OnBossSpawned.Invoke();

    }
    public void DefeatBoss()
    {
        levelsBeaten++;
        //calls the event and invokes all registered callbacks
        OnBossBeaten.Invoke();

    }


    //unsure if being used
    public void RestartGame()
    {
        Time.timeScale = 1f;
        
        LevelManager.Instance.RestartLevel();
    }

    //handles pausing the game by setting the timescale to zero and telling the UImanager to toggle the pause menu
    public void PauseGame()
    {
        Time.timeScale = 0f;
        UIManager.Instance.TogglePausePanel();
        
    }
    //handles resuming the game by setting the timescale to 1 and telling the UImanager to toggle the pause menu
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        UIManager.Instance.TogglePausePanel ();
        
    }



    // Update is called once per frame
    void Update()
    {
        //ensure the list accounts for enemies dieing and spawning
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");



       NextStage();
    }
    
    //not used anymore
    public void NextStage()
    {
          
        
        //once the boss is defeated we go to stage 3
        if (GameManager.Instance.bossDeath ==true)
        {
            //Victory
            //GameManager.Instance.stage = 3;
        }
        
    }

    //not used anymore
    //used so the scripts know the player is aalive
    public void PlayerSpawn()
    {
        playerLive=true;
        


    }
    //not used anymore
    public void PlayerDeath()
    {
        //the player has died so objects stop moving
        playerLive = false;
        
        


    }
    //used to move to the next stage once the boss has died
    //not used anymore
    public void BossSpawn()
    {
        bossDeath = false;
        

    }
    //not used anymore
    public void BossDeath()
    {
        bossDeath=true;

    }
   


}

