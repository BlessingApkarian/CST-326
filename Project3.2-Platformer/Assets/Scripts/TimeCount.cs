using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    public TextMeshProUGUI timeCounter;
    public float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = timeRemaining.ToString();
        timeRemaining = 100;
    }
   

    void Update()
    {
        if (timeRemaining > 0 && !DisplayStatus.won)
        {
            timeRemaining -= Time.deltaTime;
            int timeR = (int)timeRemaining; // because (int)Time.deltaTime does not work
            timeCounter.text = timeR.ToString();
        }
        else
        {
            DisplayStatus.lost = true;
        }
    }
}
