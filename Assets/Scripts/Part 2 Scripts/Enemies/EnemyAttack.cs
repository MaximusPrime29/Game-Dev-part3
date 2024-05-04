using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public int attackDamage = 10;
    public float attackCooldown = 1.5f;
    public Transform player;
    public PlayerHealth playerHealth;
    public bool canAttack = false;


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("playercollison");
            
            //if the enemy collides with the player the canattack method is called 
            //could just use the attack method
            CanAttackPlayer();
        }


    }




    private void Awake()
    {
        //assigns the object with the playe rtag to the playerObject variable
        GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");
        foreach (var pl in playerObject)
        {
            if (pl.GetComponent < PlayerHealth>())
            {
                player = pl.transform;
                playerHealth = pl.GetComponent<PlayerHealth>();
            }
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack== true)
        {
            AttackPlayer();
        }
        


        
        
    }
    //checks if the enemy can attack the player
    //at the moment this method does not do much 
    public bool CanAttackPlayer()
    {
        canAttack = true;
       


        return canAttack;
    }

    //the player is attacked and takes damage
    private void AttackPlayer()
    {
        playerHealth.Takedamage(attackDamage);


    }
}