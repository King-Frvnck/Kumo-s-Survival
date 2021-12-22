using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlammeCollisionScript : MonoBehaviour
{
    public GameObject lanceFlamme;
    public GameObject flamme;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Flamme"))
        {
            flamme.transform.position = lanceFlamme.transform.position;
        }
    }
}
