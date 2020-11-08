using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
  public List<Enemy> currentEnemies;
  public Enemy currentTarget;

  public GameObject turret;
  private LineRenderer lineRenderer; 

  void Start()
  {
    lineRenderer = GetComponent<LineRenderer>();
  }

  void OnDrawGizmos()
  {
    Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius); // draw circle around tower
  }

  void Update()
  {
    if (currentTarget)
    {
      lineRenderer.SetPosition(0, turret.transform.position); // draw line beteween tower and current enemy target 
      lineRenderer.SetPosition(1, currentTarget.transform.position);
    }
  }

  void OnTriggerEnter(Collider collider) // enemy enters sphere (tower hit radius)
  {
    Enemy newEnemy = collider.GetComponent<Enemy>(); // enemy that enters sphere is a new enemy
    currentEnemies.Add(newEnemy); // new enemy gets added to enemies list

    newEnemy.DeathEvent.AddListener(delegate { BookKeeping(newEnemy);}); // subscribe to death event, when the enemy dies, tower needs to know

    EvaluateTarget(newEnemy);

    //Debug.Log($"{collider.name} has entered");
  }

  void OnTriggerExit(Collider collider)
  {
    Enemy enemyLeaving = collider.GetComponent<Enemy>();

    //enemyLeaving.DeathEvent.RemoveListener(delegate { BookKeeping(enemyLeaving);}); //unsubscribing to the DeathEvent for this enemy .... don't care anymore :(

    currentEnemies.Remove(enemyLeaving);  // enemy leaving the circle, remove from enemy list
    EvaluateTarget(enemyLeaving);

  }

  private void BookKeeping(Enemy enemy)
  {
    currentEnemies.Remove(enemy);
    EvaluateTarget(enemy);

  }


  private void EvaluateTarget(Enemy enemy)// if the enemy the tower is currently targeting is the enemy being evaluated 
  {
    if (currentTarget == enemy) // if enemy target is leaving sphere, reset currentTarget value
    {
      currentTarget = null;
      lineRenderer.enabled = false;
    }

    if (currentTarget == null) // if no enemy is being targeted, set first enemy in list (first to enter the sphere) to current target
    {
      currentTarget = currentEnemies[0];
      lineRenderer.enabled = true;
    }
  }
}
