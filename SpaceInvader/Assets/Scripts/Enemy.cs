using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject particleEffect;
    public GameObject bullet;

    public Transform enemy;
    public Transform shottingOffset;

    public static bool enemyHit = false;

    public string type = "";
    public static int score = 10;
    private float timer = 0;

    [SerializeField] private float amplitude = 1;


    void Update()
    {
        timer += Time.deltaTime;

        // moving enemies
        enemy.Translate(Vector2.right * amplitude * Time.deltaTime);

        // detect if reached an edge
        RaycastHit2D hitRight = Physics2D.Raycast(enemy.position, Vector2.right, 0.2f);
        
        // TODO: Instead of if O, mothership will call enemy.fire()
        if (timer > 3 && gameObject.tag == "bot")
        {
            Fire();
            timer = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("oof!");

        if (collision.gameObject.tag == "boundary")
        {
            MotherShip.moveDown = true;
            // moving enemies
            MoveDown();

            if (MotherShip.moveRight == true)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        } else
        {
            if(gameObject.tag == "bot")
            {
                score = 10;
            } else if (gameObject.tag == "mid")
            {
                score = 20;
            }else if (gameObject.tag == "top")
            {
                score = 30;
            }
            // destroy bullet
            Destroy(collision.gameObject);
            // destroy enemy
            Destroy(gameObject);
            // incrememnt score
            ScoreKeeper.scoreUp = true;
            // start particle explosion
            GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.identity);
            // end explosion after 2 seconds
            Destroy(particle, 2f);
        }

        
    }

    void MoveDown()
    {
        enemy.Translate(Vector2.down * amplitude);
        enemy.Translate(Vector2.down * 0);
    }

    void MoveLeft()
    {
        enemy.Translate(Vector2.left * amplitude * Time.deltaTime);
        MotherShip.moveRight = false;
        MotherShip.moveLeft = true;
    }

    void MoveRight()
    {
        enemy.Translate(Vector2.right * amplitude * Time.deltaTime);
        MotherShip.moveRight = true;
        MotherShip.moveLeft = false;
    }

    public void Fire()
    {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);
    }

}
