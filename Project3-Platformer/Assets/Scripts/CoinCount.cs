using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public TextMeshProUGUI coinCounter;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        coinCounter.text = "Coinsx" + count;
    }

    // Update is called once per frame
    void Update()
    {
        if (ClickObject.qClicked)
        {
            count++;
            ClickObject.qClicked = false;
        }
        coinCounter.text = "Coinsx" + count;
    }
}
