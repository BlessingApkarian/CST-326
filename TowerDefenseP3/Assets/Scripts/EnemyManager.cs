using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Group
{
  public GameObject enemyType;
  [Range(0,50)] public int amountOfEnemies;
  [Range(0,5)] public float timeDelayBetweenEnemies;

  public Group(GameObject enemyType, int amountOfEnemies, float timeDelayBetweenEnemies)
  {
    this.enemyType = enemyType;
    this.amountOfEnemies = amountOfEnemies;
    this.timeDelayBetweenEnemies = timeDelayBetweenEnemies;
  }
}

[System.Serializable]
public struct Wave
{
  public Group[] enemyGroups;
}


public class EnemyManager : MonoBehaviour
{
 //Figure out what enemy waves look like and how to handle them (e.g. spawning, how many, wait time in between)
 

 //Pass navigational path
 public Waypoints[] topNavPoints;
 public Waypoints[] botNavPoints;
 public Wave enemyWave;
 //public GameObject easyEnemy;
 //public GameObject hardEnemy;


 void Start()
 {
   SpawnWave();
 }

 private void SpawnWave()
 {

   foreach (Group group in enemyWave.enemyGroups)
   {
     StartCoroutine(SpawnGroup(group));
     
   }
 }

 IEnumerator SpawnGroup(Group enemyGroup)
 {
   int i = 0;
   while (enemyGroup.amountOfEnemies > 0)
   {
     GameObject spawnedEnemy = Instantiate(enemyGroup.enemyType);
            Debug.Log(spawnedEnemy.name);
            if(spawnedEnemy.name.Contains("EasyEnemy"))
            {
                Debug.Log("easy");

                spawnedEnemy.GetComponent<Enemy>().StartEnemy(topNavPoints);
            } else if (spawnedEnemy.name.Contains("HardEnemy Variant"))
            {
                Debug.Log("hard");

                spawnedEnemy.GetComponent<Enemy>().StartEnemy(botNavPoints);
            }
     
     spawnedEnemy.name = $"{enemyGroup.enemyType.ToString()} {i}";
     enemyGroup.amountOfEnemies--;
     i++;
     yield return new WaitForSeconds(enemyGroup.timeDelayBetweenEnemies);
     
   }
   
  }
}
