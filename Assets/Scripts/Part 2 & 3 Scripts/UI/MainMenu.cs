using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    
    // Update is called once per frame
    void Update()
    {
        

        
    }
    
    public void QuitGame()
    {
        AudioManager.Instance.PlayButtonPressSound();
        Application.Quit();
    }
    
    public void ReloadLevel()
    {
        AudioManager.Instance.PlayButtonPressSound();
        LevelManager.Instance.currentLevelName = "Level1";
        //Loads level1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        GameManager.Instance.ResetObstaclesAndlevel();

    }

}

