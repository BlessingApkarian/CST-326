using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayStatus : MonoBehaviour
{

    public TextMeshProUGUI status;
    public TextMeshProUGUI score;

    private int highScore = 0;

    public static bool lost;
    public static bool won;

    // Start is called before the first frame update
    void Start()
    {
        status.text = "";
        score.text = "0-0-0-0-0";
    }

    // Update is called once per frame
    void Update()
    {
        if (CoinCount.collected)
        {
            highScore = CoinCount.count * 100;
        }
        if (HitBrick.brickDestroyed)
        {
            highScore += 100;
        }
        
        if (lost)
        {
            status.text = "Game Over!";
        }
        if (won)
        {
            status.text = "You Won!";
        }
        CoinCount.collected = false;
        HitBrick.brickDestroyed = false;
        score.text = highScore.ToString();
    }
}
