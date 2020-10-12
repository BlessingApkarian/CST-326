using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    Vector3 startingPos;
    int playerLives = 3;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.playerHit)
        {
            playerLives -= 1;
            // player will be destroyed on collition and will be brought back here
            GameObject playerBody = Instantiate(player, startingPos, Quaternion.identity);
        }
        Player.playerHit = false;
        Debug.Log(playerLives);
    }

    private void Reset()
    {

    }
}
