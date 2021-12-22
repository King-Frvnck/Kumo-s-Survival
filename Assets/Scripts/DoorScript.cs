using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject Key;
    public Animator fadeSystem;
    

    private void Update()
    {
      if(Key == false)
      {
        GetComponent<Collider2D>().enabled = true;
      }else
      {
        GetComponent<Collider2D>().enabled = false;
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player"))
       {
         StartCoroutine(loadNextMap(collision));
       }
    }

    public IEnumerator loadNextMap(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = GameObject.FindGameObjectWithTag("DoorB").transform.position;
    }
  
}
