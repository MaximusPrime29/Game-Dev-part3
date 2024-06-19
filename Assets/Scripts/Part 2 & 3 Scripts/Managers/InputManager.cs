using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           

            if (Time.timeScale==0f)
            {
                Time.timeScale = 1f;
                UIManager.Instance.TogglePausePanel();
                //tells the ui manager to resume the game
               

            }
            else
            {
                Time.timeScale = 0f;
                UIManager.Instance.TogglePausePanel();
                //tells the ui manager to pause the game
                

            }
            
        }

        
        
    }

   
}
