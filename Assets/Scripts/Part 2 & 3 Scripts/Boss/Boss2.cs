using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public GameObject pooPilePrefab; // Assign the poo pile prefab in the inspector
    public float spawnInterval = 1f; // Interval between drops

  
    

    // Hardcoded spawn points
    private Vector3[] spawnPoints = new Vector3[]
    {
        new Vector3(-3f, 11f, 8f),
        new Vector3(0f, 11f, 8f),
        new Vector3(3f, 11f, 8f)
    };

    private bool spawningActive = false;

    void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
            spawningActive = true;
            StartCoroutine(SpawnPooPiles());
     
    }

    

    private IEnumerator SpawnPooPiles()
    {
        while (spawningActive)
        {
            SpawnPooPile();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnPooPile()
    {
        // Randomly select a spawn point
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[spawnIndex];

        // Instantiate the poo pile at the selected spawn point
        Instantiate(pooPilePrefab, spawnPosition, Quaternion.identity);
    }
}
