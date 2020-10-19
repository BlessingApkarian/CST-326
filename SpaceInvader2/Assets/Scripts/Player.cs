using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  private Animator playerAnimator;

  public Transform shoottingOffset;

  void Start()
  {
    playerAnimator = GetComponent<Animator>();
  }

    // Update is called once per frame
    void Update()
    {
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
            GetComponent<Animator>().SetTrigger("Death");
            Destroy(collision.gameObject); // destroy bullet
            Destroy(gameObject, 1f); // destroy enemy (after 1 second so we can see the death animation)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // go to end credits when player dies
        }

    }
}
