using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private Text leftTextScore;
    [SerializeField] private Text rightTextScore;

    [SerializeField] private Goal leftGoal;
    [SerializeField] private Goal rightGoal;

    [SerializeField] private GameManager gameManager;


    private int leftScore = 0;
    private int rightScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        RefreshScore();
    }

    private void RefreshScore()
    {
        leftTextScore.text = leftScore.ToString();
        rightTextScore.text = rightScore.ToString();
    }
    public void AddScore(Goal scoringSide)
    {
        if (scoringSide == leftGoal) {
            rightScore += 1;
        } else {
            leftScore += 1;
        }
        
        if(leftScore > 11 || rightScore > 11) {

        } else {
            RefreshScore();
        }
        
    }
}
