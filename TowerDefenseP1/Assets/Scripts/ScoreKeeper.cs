using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public TextMeshProUGUI scoreT;
    private int score = 0;
    public static bool killed = false;

    private void Start()
    {
        scoreT.text = "00000";
    }

    private void Update()
    {
        if (killed)
        {
            IncrementScore();
            killed = false;
        }
        scoreT.text = score.ToString("D5");
    }

    void IncrementScore() {
        score += Enemy.score;
    }
}
