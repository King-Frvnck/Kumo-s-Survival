using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlammeScript : MonoBehaviour
{
    Vector3 direction = new Vector3(-9, 0, 0);

    private int damageOfCollision = 20;

    public GameObject lanceFlamme;
    public GameObject CollisionF;

    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<Collider2D>())
        {
            transform.position = lanceFlamme.transform.position;
        }
         
         if(collision.transform.GetComponent<CapsuleCollider2D>())
        {
            KumoHealth kumoHealth = collision.transform.GetComponent<KumoHealth>();
            kumoHealth.TakeDamage(damageOfCollision);
        }
    }
}
