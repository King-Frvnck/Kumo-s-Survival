using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMonster : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public int damageOfCollision = 20;

    public SpriteRenderer graphics;
    private Transform target;
    private int destPointM = 0;
    
    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
  
        //Si l'ennemi est quasiment arrivé à sa destination 
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPointM = (destPointM + 1) % waypoints.Length;
            target = waypoints[destPointM];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<CapsuleCollider2D>())
        {
            KumoHealth kumoHealth = collision.transform.GetComponent<KumoHealth>();
            kumoHealth.TakeDamage(damageOfCollision);
        }
    }
}
