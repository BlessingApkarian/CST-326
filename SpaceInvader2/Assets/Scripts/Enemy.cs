using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      GetComponent<Animator>().SetTrigger("Death");
      Destroy(collision.gameObject); // destroy bullet
      Destroy(gameObject, 1f); // destroy enemy (after 1 second so we can see the death animation)
      Debug.Log("Ouch!");
    }
}
