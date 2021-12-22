using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject Key;

    private bool closeCondition;
    public Animator topDoorCloseAnim;
    public Animator bottomDoorCloseAnim;

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.CompareTag("Player"))
       {
        Destroy(gameObject);
        topDoorCloseAnim.SetBool("closeCondition", true);
        bottomDoorCloseAnim.SetBool("closeCondition", true);
       }else
       {
        gameObject.SetActive(true);
        topDoorCloseAnim.SetBool("closeCondition", false);
        bottomDoorCloseAnim.SetBool("closeCondition", false);
       }
   }
}
