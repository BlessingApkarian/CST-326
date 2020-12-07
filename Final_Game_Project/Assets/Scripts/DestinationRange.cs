using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationRange : MonoBehaviour
{
    public int xPos;
    public int zPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            xPos = Random.Range(68, 88);
            zPos = Random.Range(-35, -27);
            this.gameObject.transform.position = new Vector3(xPos, 0, zPos);
        }
    }
}
