using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform player;
    public Transform shottingOffset;

    public GameObject bullet;

    private float velocityPlayer = 0;

    public static bool playerHit = false;

    [SerializeField] private float amplitude = 1;

    void Update()
    {
        velocityPlayer = Input.GetAxis("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");

            Destroy(shot, 3f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");

        if(collision.gameObject.tag == "bullet")
        {
            // destroy bullet
            Destroy(collision.gameObject);
            // destroy player
            Destroy(gameObject);
            // decrement lives
            playerHit = true;
        }
        
    }

    void FixedUpdate()
    {
        MovePlayer(new Vector3(velocityPlayer, 0, 0), player);
    }

    void MovePlayer(Vector3 direction, Transform player)
    {
        player.Translate(direction * amplitude);
    }
}
