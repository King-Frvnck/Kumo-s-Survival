using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpots : MonoBehaviour
{
   
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.CompareTag("Punch"))
       {
          Destroy(transform.parent.parent.gameObject);
       }
   }
  
}
