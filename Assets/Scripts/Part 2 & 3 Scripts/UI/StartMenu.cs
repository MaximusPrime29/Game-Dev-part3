using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //public AudioSource ButtonAudioSource;
    public void StartGame()
    {
        
        Debug.Log("should start the game");
        AudioManager.Instance.PlayButtonPressSound();
        //loads the next scene which is level1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        AudioManager.Instance.PlayButtonPressSound();
        Debug.Log("Quitting game");
        Application.Quit();

    }
    public void ViewMetrics()
    {
        Debug.Log("Viewing metrics");

    }
}
