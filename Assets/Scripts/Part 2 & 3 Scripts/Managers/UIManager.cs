using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    //public GameObject pause;

    //public float menuNum = 0;
    
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI levelsBeatenText;


    private CanvasGroup pausePanelCanvasGroup;

    //used to switch between the canva being visible and invisibible
    private bool isPausePanelVisible = false;

    //trying to get the ui eleemnts to properly display in lvele 2
    public string currentUILevel;
    

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
    private void Start()
    {
        //Find the score and levels beaten text in the scene
        UpdateScoreTextReference();
        UpdateLevelsBeatenTextReference();

        // Subscribe to GameManager events
        //when the event onObstacle passed it happens the Uimanager does the updatescore method
        GameManager.Instance.OnObstaclePassed.AddListener(UpdateScore);
        GameManager.Instance.OnBossBeaten.AddListener(UpdateLevelsBeaten);

        //find the pausepanel 
        GameObject pausePanel = GameObject.FindGameObjectWithTag("Level1PausePanel");
        pausePanelCanvasGroup = pausePanel.GetComponent<CanvasGroup>();

        //TogglePauseMenu();


    }
    private void Update()
    {
        //trying to get the ui to show the score and levels beaten correctly when you get to the next level
        if (currentUILevel != LevelManager.Instance.currentLevelName)
        {
            UpdateScoreTextReference();
            UpdateLevelsBeatenTextReference();
            currentUILevel = LevelManager.Instance.currentLevelName;

        }
    }

    //unsure what the method is use dfor 
    public void NextLevelFind()
    {
        UpdateScoreTextReference();
        UpdateLevelsBeatenTextReference();

    }

    // a method for finding the score text 
    private void UpdateScoreTextReference()
    {
        //looks for an object with the tag 
        GameObject scoreObject = GameObject.FindGameObjectWithTag("Level1Score");
        if (scoreObject != null)
        {
            // gets the text element of the object
            scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
            if (scoreText != null)
            {
                //debug
                Debug.Log("Score text found: " + scoreText.gameObject.name);
            }
            else
            {
                //debug
                Debug.LogWarning("Score text component not found on GameObject with tag: ScoreText");
            }
        }
        else
        {
            //debug
            Debug.LogWarning("Score text GameObject not found with tag: ScoreText");
        }

    }
    //a method for finding the levels beaten text 
    public void UpdateLevelsBeatenTextReference()
    {
        
        GameObject levelsBeatenObject = GameObject.FindGameObjectWithTag("Level1LevelsBeaten");
        levelsBeatenText=levelsBeatenObject.GetComponent<TextMeshProUGUI>();

    }
    //a method for updating the levels beaten text
    public void UpdateLevelsBeaten()
    {
        //we have to re assign the object as unity is unable to keep the reference from the method that finds the levels beaten text
        GameObject levelsBeatenObject = GameObject.FindGameObjectWithTag("Level1LevelsBeaten");
        levelsBeatenText = levelsBeatenObject.GetComponent<TextMeshProUGUI>();
        levelsBeatenText.text = "Levels Beaten :" + GameManager.Instance.GetLevelsBeaten().ToString();
    }
   
    //unsure what the method is used for 
    public void Startgame()
    {

        SceneManager.LoadScene("Level1");
    }

    //unsure what method is used for
    public void Initialize()
    {
        // Initialize UI elements if needed
    }

    public void UpdateScore()
    {
        //we have to refind the text reference
        UpdateScoreTextReference();


        //if the text is not null
        if (scoreText.text != null)
        {
           
            scoreText.text = "Score: " + GameManager.Instance.GetObstaclesPassedScore().ToString();
            
            //Debug.Log("Score text updated: " + scoreText.text); // Log the updated text value
        }
        else
        {
            Debug.LogWarning("Score text is null");
            
        }

    }
    //used for toggling the pause menu on and off 
    public void TogglePausePanel()
    {
        //find it using the tag
        GameObject pausePanel = GameObject.FindGameObjectWithTag("Level1PausePanel");

        //gets the componenet
        pausePanelCanvasGroup = pausePanel.GetComponent<CanvasGroup>();
        if (pausePanelCanvasGroup == null)
        {
            Debug.LogWarning("Pause panel CanvasGroup is null, cannot toggle visibility.");
            return;
        }
        //switches between true and false
        isPausePanelVisible = !isPausePanelVisible;
        if (isPausePanelVisible)
        {
            ShowPauseMenu();
        }
        else
        {
            HidePauseMenu();
        }
    }

    public void ShowPauseMenu()
    {
        if (pausePanelCanvasGroup != null)
        {
            //sets the colout to white
            pausePanelCanvasGroup.alpha = 1f;
            //you can interact with it
            pausePanelCanvasGroup.interactable = true;
            pausePanelCanvasGroup.blocksRaycasts = true;
            Debug.Log("Pause menu shown.");
        }
        else
        {
            Debug.LogWarning("Pause panel CanvasGroup is null, cannot show pause menu.");
        }
    }

    public void HidePauseMenu()
    {
        if (pausePanelCanvasGroup != null)
        {
            //sets the colout to transparent
            pausePanelCanvasGroup.alpha = 0f;
            //you can not interact with it 
            pausePanelCanvasGroup.interactable = false;
            pausePanelCanvasGroup.blocksRaycasts = false;
            Debug.Log("Pause menu hidden.");
        }
        else
        {
            Debug.LogWarning("Pause panel CanvasGroup is null, cannot hide pause menu.");
        }
    }

   
    



}