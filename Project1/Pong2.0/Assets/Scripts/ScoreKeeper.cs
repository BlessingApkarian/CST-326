using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private Text leftTextScore;
    [SerializeField] private Text rightTextScore;
    [SerializeField] private Text winner;

    [SerializeField] private Goal leftGoal;
    [SerializeField] private Goal rightGoal;

    [SerializeField] private GameManager gameManager;

    public static bool gameOver = false;

    public static int leftScore = 0;
    public static int rightScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        leftTextScore.text = "0";
        rightTextScore.text = "0";
        winner.text = " ";
        RefreshScore();
    }

    private void RefreshScore()
    {
        //some function to update the Text string
        rightTextScore.text = rightScore.ToString();
        leftTextScore.text = leftScore.ToString();
        winner.text = " ";
    }

    public void AddScore(Goal scoringSide)
    {
        if (scoringSide == leftGoal)
        {
            rightScore += 1;
            rightTextScore.color = Random.ColorHSV(0f, 1f, 1f, 0.5f, 0.5f, 1f);
        }
        else
        {
            leftScore += 1;
            leftTextScore.color = Random.ColorHSV(0f, 1f, 1f, 0.5f, 0.5f, 1f);
        }

        IsWon();
        RefreshScore();
    }

    public void IsWon()
    {
        if (rightScore == 11)
        {
            winner.text = "Game Over. Right Player Wins!";
            StartCoroutine(Pause());
            gameOver = true;
            ResetScore();
        }
        if (leftScore == 11)
        {
            winner.text = "Game Over. Left Player Wins!";
            gameOver = true;
            StartCoroutine(Pause());
            ResetScore();
        }
    }

    public void ResetScore()
    {
        leftScore = 0;
        rightScore = 0;
        rightTextScore.color = Color.white;
        leftTextScore.color = Color.white;
    }

    public IEnumerator Pause()
    {
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;

    }
}
