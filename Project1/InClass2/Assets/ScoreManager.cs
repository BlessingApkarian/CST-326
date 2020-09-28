using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI score;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score is: " + counter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementCount()
    {
        counter++;
        //score.text = "Score is: " + counter;
        score.text = $"Score is {DeterminFontSize()}{counter}</size> Hay is for Horses";
    }

    // can do something like private (string, string) methodName()
    private string DeterminFontSize()
    {
        //string result = (counter > 5) ? "<size=20%>" : "<size=80%>";
        string result = (counter > 5) ? "<color=red>" : "<color=green>";

        return result;
    }
}
