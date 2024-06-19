using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.CloudSave;
using UnityEngine;
using Unity.Services.CloudSave.Models;

public class CloudSavemanager : MonoBehaviour
{
    public static CloudSavemanager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static async Task SaveData(int score,string playerID)
    {
        Dictionary<string, object> data = new Dictionary<string, object>()
        {
            { "Highscore", score },
            { "PlayerID", playerID }

        };
        Dictionary<string, string> result = await CloudSaveService.Instance.Data.Player.SaveAsync(data);
        
        
       
    }

    public static async Task<Item> LoadData()
    {
        Dictionary<string, Item> result = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string>()
        {
            "Highscore"
        });

        return result["Highscore"];
    }
}
