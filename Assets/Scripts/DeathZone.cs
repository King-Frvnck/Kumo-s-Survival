using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
  private Transform playerSpawn;
  private Animator fadeSystem;
  private int damageOfCollision = 100;

  private void Awake()
  {
    playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.CompareTag("Player"))
    {
      StartCoroutine(ReplacePlayer(collision));
    }

      if(collision.transform.GetComponent<CapsuleCollider2D>())
        {
            KumoHealth kumoHealth = collision.transform.GetComponent<KumoHealth>();
            kumoHealth.TakeDamage(damageOfCollision);
        }
  }

  public IEnumerator ReplacePlayer(Collider2D collision)
  {
      
      yield return new WaitForSeconds(1f);
      collision.transform.position = playerSpawn.position;
  }
}
