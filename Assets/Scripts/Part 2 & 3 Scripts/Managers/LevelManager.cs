using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public string Level1Name = "Level1";
    public string Level2Name = "Level2";
    public UnityEvent OnNextLevelLoad;

    public string currentLevelName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public void Initialize()
    {
        // Initialize UI elements if needed
    }
   
    
    //restarts the level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        if (OnNextLevelLoad == null) OnNextLevelLoad = new UnityEvent();
        LoadFirstLevel();
    }

    public void LoadFirstLevel()
    {
        currentLevelName = Level1Name;
        SceneManager.LoadScene(Level1Name);
    }

    public void LoadSecondLevel()
    {
        currentLevelName = Level2Name;
        SceneManager.LoadScene(Level2Name);
    }
    public void FromGameoverToLevel1()
    {
        currentLevelName = Level1Name;
        SceneManager.LoadScene(Level1Name);
        GameManager.Instance.ResetObstaclesAndlevel();
        
        

    }

    public void LoadNextLevel()
    {
        //if the current level is level1 then it loads level 2
        if (currentLevelName == Level1Name)
        {
            LoadSecondLevel();
            OnNextLevelLoad.Invoke();
        }
        else
        {
            LoadFirstLevel();
            OnNextLevelLoad.Invoke();
        }
    }
    //loads the gameover scen when the player dies
    public void PlayerDied()
    {
        
        SceneManager.LoadScene("GameOver 1");
        currentLevelName = "GameOver 1";
    }
}
