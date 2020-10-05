using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public TextMeshProUGUI coinCounter;
    public static int count = 0;
    public static bool collected = false;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        collected = false;
        coinCounter.text = "Coinsx" + count;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            count++;
            collected = true;
            Destroy(collision.gameObject);
        }
        coinCounter.text = "Coinsx" + count;
    }
}
