using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform player;

    public GameObject bullet;

    private float velocityPlayer = 0;

    public Transform shottingOffset;

    [SerializeField] private float amplitude = 1;

    // Update is called once per frame
    void Update()
    {
        velocityPlayer = Input.GetAxis("Horizontal");
        Debug.Log(velocityPlayer);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");

            Destroy(shot, 3f);
        }
    }

    void FixedUpdate()
    {
        MovePlayer(new Vector3(velocityPlayer, 0, 0), player);
    }

    void MovePlayer(Vector3 direction, Transform player)
    {
        player.Translate(direction * amplitude);
    }
}
