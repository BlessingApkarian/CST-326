using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Ball : MonoBehaviour
{

    [SerializeField] private float amplitude;
    [SerializeField] private float step;
    private float startAmplitude;

    public static bool restart = false;
    public static bool lastHitLeft = false;
    public static bool lastHitRight = false;

    private Rigidbody rb;
    
    public Vector2 startPos;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startAmplitude = amplitude;
        startPos = this.transform.position;
    }

    // Update is called once per frame
    public void Restart()
    {
        amplitude = startAmplitude;
        rb.MovePosition(Vector3.zero);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * amplitude; // change to send to losing side
        restart = true;
        lastHitRight = false;
        lastHitLeft = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight")
        {
            //play sound
            collision.gameObject.GetComponent<Paddle>().MadeContact();

            amplitude += step;
            float offset = Mathf.Pow((transform.position.z - collision.transform.position.z), 2);
            offset = (transform.position.z - collision.transform.position.z < 0) ? offset * -1 : offset;

            rb.velocity = (collision.gameObject.name == "PaddleLeft")
                ? new Vector3(amplitude, 0, offset)
                : new Vector3(-amplitude, 0, offset);
        }

        if(collision.gameObject.name == "PaddleLeft")
        {
            lastHitLeft = true;
            lastHitRight = false;
        }
        if(collision.gameObject.name == "PaddleRight")
        {
            lastHitLeft = false;
            lastHitRight = true;
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "LeftGoal")
        {
            setPositionLeft();
        }
        if (other.gameObject.name == "RightGoal")
        {
            setPositionRight();
        }
    }

    void setPositionLeft()
    {
        this.transform.position = startPos;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * amplitude;
    }

    void setPositionRight()
    {
        this.transform.position = startPos;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * amplitude;
    }

}
