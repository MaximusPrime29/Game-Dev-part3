using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyy : MonoBehaviour
{

    //this is used for the collideer behind the player 
    public GameManager gm;
    //the value the score goes up by when an enemy is killed
    public int KillReward = 5;

    private void OnTriggerEnter(Collider other)
    {
        

        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player has died");
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("In destroy the enemy has collided with the wall");
            GameManager.Instance.IncrementObstaclesPassedScore();

            //if an enemy hits the collider behind the player the gamemanger is told to increase the score and the killcount
            GameManager.Instance.score += KillReward;
            //GameManager.Instance.kills += 1;

            Debug.Log("enemy has been destroyed");
            Destroy(other.gameObject);
            
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            //if the boss hit the collider the game manager is notified and the boss is destroyed
            gm.BossDeath();
            Destroy(other.gameObject);

        }

    }

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }


}
