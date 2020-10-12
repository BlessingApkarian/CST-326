using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class MotherShip : MonoBehaviour
{
    public static bool moveRight;
    public static bool moveLeft;
    public static bool moveDown;

    public GameObject[] enemies;

    void Start()
    {
        moveRight = true;
        moveLeft = false;
        moveDown = false;
    }


    void Update()
    {
        if(enemies.Length == 0)
        {
            LevelUp();
        }
        if(enemies.Length < 10)
        {
            SpeedUp();
        }
        if(enemies.Length < 5)
        {
            SpeedUp();
        }
        if(moveDown == true)
        {
            moveDown = false;
        }
    }

    void LevelUp()
    {
        
    }

    void SpeedUp()
    {

    }
}
