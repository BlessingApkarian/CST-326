using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTower : MonoBehaviour
{
    Restart r;

    private void Start()
    {
        r = GetComponent<Restart>();
    }

    public int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        count++;

        if(count > 3)
        {
            Destroy(gameObject);
            r.restartGame();
        }
    }

}
