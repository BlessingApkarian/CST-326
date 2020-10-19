using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform shoottingOffset;
    public GameObject bullet;

    Rigidbody2D rb;
    private float vel = 3;

    private float timer = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(vel, rb.velocity.y);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer > 3 && gameObject.tag == "Bot")
        {
            Fire();
            timer = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boundary")
        {
            Debug.Log("Boop!");
            vel = vel * -1; // change direction
            rb.velocity = new Vector2(vel, rb.velocity.y); // set direction
        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("EnemyBullet!");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Death");
            Destroy(collision.gameObject); // destroy bullet
            Destroy(gameObject, 1f); // destroy enemy (after 1 second so we can see the death animation)
            Debug.Log("Ouch!");
        }
     
    }

    public void Fire()
    {
        GameObject shot = Instantiate(bullet, shoottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 2f);
    }

}
