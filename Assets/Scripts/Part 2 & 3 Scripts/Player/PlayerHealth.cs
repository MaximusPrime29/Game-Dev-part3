using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHealth : MonoBehaviour
{
    // used for the players health
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject player;
    //public GameManager gm;
    

   
    private void Awake()
    {
        
        currentHealth = maxHealth;

        //gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //gm.PlayerSpawn();
        //GameManager.Instance.PlayerSpawn();
        

    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.PlayerSpawn();


    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void Takedamage(int dam)
    {
        currentHealth -= dam;
        //Debug.Log($"{currentHealth}");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health stays within bounds

        if (currentHealth <=0) 
        {
            //if the players health is 0 they are destoyed and the game manager is notified
            currentHealth = 0;
            //calls the die method
            AudioManager.Instance.PlayDeathSound();
            
            GameManager.Instance.PlayerDeath();
            Die();
           

            Destroy(gameObject);
            




        }

    }
    //tells the levelmanager to do the playerdied method which loads the game over scene
    private void Die()
    {
        if (LevelManager.Instance == null)
        {
            Debug.LogError("LevelManager.Instance is null");
            return;
        }
        LevelManager.Instance.PlayerDied();

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null");
            return;
        }
        int score = GameManager.Instance.GetObstaclesPassedScore();

        if (PlayerID.Instance == null)
        {
            Debug.LogError("PlayerID.Instance is null");
            return;
        }
        string playerID = PlayerID.Instance.PlayerId;

        if (CloudSavemanager.Instance == null)
        {
            Debug.LogError("CloudSavemanager is null");
            return;
        }
        CloudSavemanager.SaveData(score, playerID);
    }

}
