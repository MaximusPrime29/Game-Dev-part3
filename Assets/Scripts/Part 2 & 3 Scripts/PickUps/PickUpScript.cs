using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //used for the first pickup

    //public AudioSource pickUpFX;
    private void OnTriggerEnter(Collider other)
    {
        //if the player collides with the pickup the pickup manager is notified and the object is destroyed
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayJumpBoostSound();
            GameManager.Instance.ActivatePickup1();
            
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
  
}
