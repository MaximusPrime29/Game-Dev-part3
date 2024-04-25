using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health = 100;
    public int damageTaken = 50;


    private void Awake()
    {
        health = 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0) 
        { 
            Destroy(gameObject);


        }
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

    }
   
}