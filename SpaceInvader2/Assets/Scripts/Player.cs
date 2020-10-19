using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public GameObject bullet;
    private Animator playerAnimator;
    public Transform player;
    public Transform shoottingOffset;

    private float velocityPlayer = 0;

    [SerializeField] private float amplitude = 1;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocityPlayer = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {

            playerAnimator.SetTrigger("Shoot");
            GameObject shot = Instantiate(bullet, shoottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");

            Destroy(shot, 3f);

        }
        // TODO: if shot, go to credits
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boundary")
        {
            Debug.Log("Player Boop!");
        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            Invoke("goToCredits", 1f); // Invoke goes to the method in first param, second param is the time elapsed before going to said method
            GetComponent<Animator>().SetTrigger("Death");
            Destroy(collision.gameObject); // destroy bullet
            Destroy(gameObject, 1f); // destroy enemy (after 1 second so we can see the death animation)
            Debug.Log("goToCredits");
            
        }
    }

    private void goToCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // go to end credits when player dies
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
