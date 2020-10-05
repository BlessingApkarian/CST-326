using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HitBrick : MonoBehaviour
{
    public static bool brickDestroyed = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Brick"))
        {
            brickDestroyed = true;
            Destroy(collision.gameObject);
        }
    }

}
