using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public static bool scaleLeftPaddleDown;
    public static bool scaleRightPaddleDown;

    private void OnTriggerEnter(Collider other)
    {
        //do something interesting to the ball, paddle, or some other game element
        Debug.Log(other.gameObject.name); // Ball

        if (ScoreKeeper.leftScore > ScoreKeeper.rightScore)
        {
            scaleLeftPaddleDown = true;
        } 
        else if(ScoreKeeper.leftScore < ScoreKeeper.rightScore)
        {
            scaleRightPaddleDown = true;
        }
    }
}
