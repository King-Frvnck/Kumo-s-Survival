using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileBlock : MonoBehaviour
{
  void OnCollisionEnter2D(Collision2D collision)
  {
      if(collision.gameObject.name == "Kumo")
      {
          Destroy(gameObject, 1);
      }
  }
}
