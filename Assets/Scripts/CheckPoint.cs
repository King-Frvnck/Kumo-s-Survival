using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
  public Transform playerSpawn;
  

  private void Awake()
  {
      playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
  } 
  
  private void OnTriggerEnter2D(Collider2D collision)
  {
      if(collision.CompareTag("Player"))
      {
          playerSpawn.transform.position = transform.position;
          
      }
  }
}
