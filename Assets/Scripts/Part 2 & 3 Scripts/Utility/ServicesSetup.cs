using System;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.CloudSave.Models;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class ServicesSetup : MonoBehaviour
{
    #region FIELDS

    [SerializeField]
    private TMP_Text _highscoreText;
    [SerializeField]
    private Button _loadButton;

    #endregion



    #region UNITY METHODS

    private async void Start()
    {
        await UnityServices.InitializeAsync();

        // Check if signed in, if not, sign in anonymously
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            AuthenticationService.Instance.SignedIn += OnSignIn;
            AuthenticationService.Instance.SignInFailed += OnSignInFailed;
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        // Load highscore data if it's the start scene or game over scene
        if (SceneManager.GetActiveScene().name == "StartScene" || SceneManager.GetActiveScene().name == "GameOverScene")
        {
            await LoadHighscore();
        }
    }

    private void OnEnable()
    {
        _loadButton.onClick.AddListener(OnLoadButtonClicked);
    }

    private void OnDisable()
    {
        _loadButton.onClick.RemoveListener(OnLoadButtonClicked);
    }

    #endregion

    #region SERVICES METHODS

    private void OnSignIn()
    {
        string playerId = AuthenticationService.Instance.PlayerId;
        PlayerID.Instance.SetPlayerId(playerId);
        //print("Signed In Successfully.");
        print(AuthenticationService.Instance.PlayerId);
        print(AuthenticationService.Instance.AccessToken);

        AuthenticationService.Instance.SignedIn -= OnSignIn;
        AuthenticationService.Instance.SignInFailed -= OnSignInFailed;
        
    }
    

    private void OnSignInFailed(RequestFailedException exception)
    {
        //print("Signed In Failed.");
        print(exception.Message);
    }

    

    #endregion

    #region BUTTON METHODS

    private async void OnLoadButtonClicked()
    {
        await LoadHighscore();
    }
    private async Task LoadHighscore()
    {
        AudioManager.Instance.PlayButtonPressSound();
        Item data = await CloudSave.LoadData();
        _highscoreText.SetText(data.Value.GetAs<int>().ToString());
        print(_highscoreText.text);
    }

    #endregion
}