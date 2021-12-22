using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerup : MonoBehaviour
{
    public int healthPoints;

   void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.CompareTag("Player"))
       { 
           if(KumoHealth.instance.currentHealth != KumoHealth.instance.maxHealth)
           {
            KumoHealth.instance.HealPlayer(healthPoints);
            Destroy(gameObject);
           }
         
       }
   }
}
