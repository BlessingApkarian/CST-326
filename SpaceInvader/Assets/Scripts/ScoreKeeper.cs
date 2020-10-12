using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    public TextMeshProUGUI space;

    int score = 0;
    int hiScore = 0;

    public static bool scoreUp = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score\n00000";
        hiScoreText.text = "Hi-Score\n00000";

        score = 0;
        hiScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            space.text = "";
        }
        if (scoreUp)
        {
            score += Enemy.score;
            hiScore += Enemy.score;
        }
        scoreUp = false;
        scoreText.text = "Score\n" + score.ToString("D5");
        hiScoreText.text = "Hi - Score\n" + hiScore.ToString("D5");
    }
}
