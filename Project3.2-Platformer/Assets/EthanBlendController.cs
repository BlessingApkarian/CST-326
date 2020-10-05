using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class EthanBlendController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private float move = 1;
    private float speed = 0;
    private float up = 10;

    public float amplify = 2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // controlls animation direction and speed
        move = Input.GetAxis("Horizontal") * amplify;
        
        // turbo
        move = (Input.GetKey(KeyCode.LeftShift)) ? move * amplify : move;
        
        // turn left or right
        float y = (move < 0) ? -90 : 90;
        Vector3 input = new Vector3(0, y, 0);
        transform.eulerAngles = input;

        // set speed, absolute value move because we can only move forward (left and right, but not backwards, no moonwalking)
        // speed is how fast the player is moving
        // move is what direction
        animator.SetFloat("Speed", Mathf.Abs(move));
        speed = animator.GetFloat("Speed");
        
        // if player is pressing left/right 
        if (move < 0 || move > 0)
        {
            // if player holds left/right, player begins to run
            if(speed > 1.95)
            {
                animator.SetBool("isRunning", true);
            } else if(speed > 0 && speed < 1.95)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", true);
            }
           
        } else if (move == 0)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        // jumping
        // jump left
        if (Input.GetKeyDown(KeyCode.Space) && move < 0)
        {
            animator.SetBool("leftJump", true);
            rb.AddForce((Vector3.up * up), ForceMode.VelocityChange);
        }
        else
        {
            animator.SetBool("leftJump", false);
        }
        // jump right
        if (Input.GetKeyDown(KeyCode.Space) && move > 0)
        {
            animator.SetBool("rightJump", true);
            rb.AddForce((Vector3.up * up), ForceMode.VelocityChange);
        }
        else
        {
            animator.SetBool("rightJump", false);
        }
        // idle jump
        if (Input.GetKeyDown(KeyCode.Space) && move == 0)
        {
            animator.SetBool("idleJump", true);
            rb.AddForce((Vector3.up * up), ForceMode.VelocityChange);
        }
        else
        {
            animator.SetBool("idleJump", false);
        }
    }

    private void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.LeftShift)))
        {
            rb.velocity = (Vector3.right * move * amplify);
        }
    }
}
