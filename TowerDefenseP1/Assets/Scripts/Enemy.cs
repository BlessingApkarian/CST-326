using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Waypoints[] NavPoints;

    private Transform target;

    private Vector3 direction;

    public float amplify = 1;
    private int index = 0;
    private bool move = true;
    private int health = 100;

    public static int score = 50;
    void Start()
    {
        health = 100;
        transform.position = NavPoints[index].transform.position;
        NextWaypoint();
        direction = target.position - transform.position;
    }

    void Update()
    {
        if (move)
        {
            transform.Translate(direction.normalized * Time.deltaTime * amplify);
            if ((transform.position - target.position).magnitude < .1f)
            {
                NextWaypoint();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool didHit = Physics.Raycast(ray, out hit, 100.0f);
            if (didHit && (hit.collider.name == "Enemy1"))
            {
                health -= 50;
            }
            Debug.Log(health);
            if(health <= 0)
            {
                Destroy(hit.collider.gameObject);
                ScoreKeeper.killed = true;
            }
        }
    }

    private void NextWaypoint()
    {
        if(index < NavPoints.Length - 1) { 
            index += 1;
            target = NavPoints[index].transform;
            direction = target.position - transform.position;
        } else
        {
            move = false;
        }
    }
}
