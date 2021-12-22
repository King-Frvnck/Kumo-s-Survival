using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresseTrapScript : MonoBehaviour
{
    Vector3 direction = new Vector3(0, -10, 0);
    private bool trapIsGrounded;

    void Start()
    {
        //Cette coroutine a pour but d'actionner un timer lorsque la trap a toucher, le timer ecouler, la trap peut remonter.
        StartCoroutine(delayTrap());
    }

    void Update()
    {
      transform.Translate(direction * Time.deltaTime);
    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.CompareTag("PressCollision"))
      {
        Vector3 direction = new Vector3(0, 0, 0);
        trapIsGrounded = true;
      }else 
      {
        trapIsGrounded = false;
      }
    }
 
  IEnumerator delayTrap()
  {
    if(trapIsGrounded == true)
    {
      yield return new WaitForSeconds(2f);
      Vector3 direction = new Vector3(0, 5, 0);
    }
  }
}
