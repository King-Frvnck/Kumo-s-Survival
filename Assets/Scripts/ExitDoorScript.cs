using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorScript : MonoBehaviour
{
    public GameObject Key;
    public GameObject victoryImage;

    private bool OpenCondition;
    public Animator OpenTheBottomDoor;
    public Animator OpenTheTopDoor;
    
    private void Update()
    {
      if(Key == false)
      {
        GetComponent<Collider2D>().enabled = true;
        OpenTheTopDoor.SetBool("OpenCondition", true);
        OpenTheBottomDoor.SetBool("OpenCondition", true);
      }else
      {
        GetComponent<Collider2D>().enabled = false;
        OpenTheTopDoor.SetBool("OpenCondition", false);
        OpenTheBottomDoor.SetBool("OpenCondition", false);
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player"))
       {
        victoryImage.SetActive(true);
       }else
       {
         victoryImage.SetActive(false);
       }
    }
}
