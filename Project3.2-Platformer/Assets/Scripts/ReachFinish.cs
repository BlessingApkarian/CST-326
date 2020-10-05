using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachFinish : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            DisplayStatus.won = true;
        }
    }
}
