using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject particleEffect;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
        // destroy bullet
        Destroy(collision.gameObject);
        // destroy enemy
        Destroy(gameObject);
        // start particle explosion
        GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.identity);
        // end explosion after 2 seconds
        Destroy(particle, 2f);
    }
}
