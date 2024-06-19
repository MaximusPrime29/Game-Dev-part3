using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    void Update()
    {
        


    }
    
    
    public void QuitGame()
    {
        AudioManager.Instance.PlayButtonPressSound();
        Debug.Log("Quitting game");
        Application.Quit();
    }

   
    public void ReloadLevel()
    {
        AudioManager.Instance.PlayButtonPressSound();
        LevelManager.Instance.FromGameoverToLevel1();
        //Loads level1
        
    }
    

}
