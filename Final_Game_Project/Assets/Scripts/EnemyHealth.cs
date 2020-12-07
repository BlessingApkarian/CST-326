using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    public int currHealth;

    private void Start()
    {
    }

    private void OnEnable()
    {
        currHealth = maxHealth;
    }

    private void Update()
    {
        if (ClickNPC.hitEnemy)
        {
            ModifyHealth(10);
            if(currHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        ClickNPC.hitEnemy = false;
    }

    void ModifyHealth(int damage)
    {
        currHealth -= damage;
    }

}
