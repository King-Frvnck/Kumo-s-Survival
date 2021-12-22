using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KumoAnimation : MonoBehaviour
{
  public bool frapAnim;
  public Animator frapAnimator;
  public float delayValue;
  public GameObject punch;
  public GameObject punchh; 

  void Update()
  {
       if(Input.GetKeyDown(KeyCode.F))
    {
        frapAnim = true;
        StartCoroutine(animatorDelay());
    }
  }

  
  IEnumerator animatorDelay()
  {

    if(frapAnim == true)
    { 
      frapAnimator.SetBool("frapAnim", true);
      punch.SetActive(true);
      punchh.SetActive(true);
      yield return new WaitForSeconds(delayValue);
      frapAnimator.SetBool("frapAnim", false);
      punch.SetActive(false);
      punchh.SetActive(false);
    }

  }
}
