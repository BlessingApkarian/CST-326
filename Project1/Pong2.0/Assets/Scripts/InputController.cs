using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Transform leftPaddle;
    public Transform rightPaddle;
    
    [SerializeField] private float amplitude = 5;

    private float velocityLeftPaddle = 0;
    private float velocityRightPaddle = 0;

    public Vector3 defaultScale;
    public Vector2 startPosLeftPaddle;
    public Vector2 startPosRightPaddle;

    public void Start()
    {
        defaultScale = leftPaddle.localScale; // only need one since they both start as the same size

        startPosLeftPaddle = leftPaddle.position;
        startPosRightPaddle = rightPaddle.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocityLeftPaddle = Input.GetAxis("LeftPaddle");
        velocityRightPaddle = Input.GetAxis("RightPaddle");

        if (ScoreKeeper.gameOver)
        {
            leftPaddle.position = startPosLeftPaddle;
            rightPaddle.position = startPosRightPaddle;
            ScoreKeeper.gameOver = false;
        }

        if (Ball.restart)
        {
            rightPaddle.localScale = defaultScale;
            leftPaddle.localScale = defaultScale;

            Ball.restart = false;
        }

        if (PowerUp.scaleRightPaddleDown && Ball.lastHitLeft)
        {
            Vector3 scale = defaultScale;
            scale.z = scale.z * 0.8f;
            rightPaddle.localScale = scale;

            PowerUp.scaleRightPaddleDown = false;
            PowerUp.scaleLeftPaddleDown = false;
            Ball.lastHitLeft = false;
        }
        if (PowerUp.scaleLeftPaddleDown && Ball.lastHitRight)
        {
            Vector3 scale = defaultScale;
            scale.z = scale.z * 0.8f;
            leftPaddle.localScale = scale;

            PowerUp.scaleLeftPaddleDown = false;
            PowerUp.scaleRightPaddleDown = false;
            Ball.lastHitRight = false;
        }

    }

    void FixedUpdate()
    {
        MovePaddle(new Vector3(0, 0, velocityLeftPaddle), leftPaddle);
        MovePaddle(new Vector3(0, 0, velocityRightPaddle), rightPaddle);
    }

    void MovePaddle(Vector3 direction, Transform paddle)
    {
        paddle.Translate(direction * amplitude);
    }

}
