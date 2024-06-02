using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject highScoreMenu;
    // Start is called before the first frame update
    void Start()
    {
        highScoreMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowHighScoreMenu()
    {
        startMenu.SetActive(false);
        highScoreMenu.SetActive(true);

    }
    public void ShowStartMenu()
    {
        startMenu.SetActive(true);
        highScoreMenu.SetActive(false);

    }
}