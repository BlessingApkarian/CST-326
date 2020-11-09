using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    public GameObject impactEffect;

    private Enemy target;

    public float speed = 5;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        target.TakeDamage(30); // target gets hit and enemy takes damage
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation); // start partical explosion
        Destroy(effect, 2f); // particle effect stops after 2 sec
        Destroy(gameObject); // destroy bullet on impact with enemy
    }

    public void Seek(Enemy _target) // get target from tower data
    {
        target = _target;
    }

}
