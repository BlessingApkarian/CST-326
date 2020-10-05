using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGoomba : MonoBehaviour
{
    public static bool hitGoomba = false;

    private void OnCollisionEnter(Collision collision)
    {
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "Ethan")
        {
            hitGoomba = true;
            DisplayStatus.lost = true;
        }
        hitGoomba = false;
    }

}
